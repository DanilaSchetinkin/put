using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase.DAO;
using Demo.Data.RemoteData.RemoteDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.Repository;

public class SQLPresenceRepositoryImpl: IPresenceRepository
{
    private readonly RemoteDatabaseContext _remoteDatabaseContext;

    public SQLPresenceRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
    {
        _remoteDatabaseContext = remoteDatabaseContext;
    }

    public void SavePresence(List<PresenceLocalEntity> presences)
    {
        foreach (var presence in presences)
        {
           
            var existing = _remoteDatabaseContext.PresenceDaos.FirstOrDefault(p =>
                p.Date == DateOnly.FromDateTime(presence.Date) &&
                p.UserGuid == presence.UserGuid &&
                p.LessonNumber == presence.LessonNumber);

            if (existing == null)
            {
                
                _remoteDatabaseContext.PresenceDaos.Add(new PresenceDao
                {
                    Date = DateOnly.FromDateTime(presence.Date),
                    IsAttedance = presence.IsAttedance,
                    LessonNumber = presence.LessonNumber,
                    UserGuid = presence.UserGuid
                });
            }
            else
            {
              
                existing.IsAttedance = presence.IsAttedance;
            }
        }

        
        _remoteDatabaseContext.SaveChanges();
    }

    public void AddPresence(PresenceLocalEntity presence)
    {
        if (presence == null) throw new ArgumentNullException(nameof(presence));

        var newPresence = new PresenceDao
        {
            Date = DateOnly.FromDateTime(presence.Date),
            UserGuid = presence.UserGuid,
            LessonNumber = presence.LessonNumber,
            IsAttedance = presence.IsAttedance
        };
        _remoteDatabaseContext.PresenceDaos.Add(newPresence);
    }

    public List<PresenceLocalEntity> GetPresenceByGroup(int groupId)
    {
        return _remoteDatabaseContext.PresenceDaos.Include(user => user.UserDao)
            .Where(p => p.UserDao != null && p.UserDao.GroupID == groupId) 
            .Select(p => new PresenceLocalEntity
            {
                Date = p.Date.ToDateTime(TimeOnly.MinValue),
                UserGuid = p.UserGuid,
                LessonNumber = p.LessonNumber,
                IsAttedance = p.IsAttedance
            })
            .ToList();
    }

    public List<PresenceLocalEntity> GetPresenceByGroupAndDate(int groupId, DateTime date)
    {
        return _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserDao != null && p.UserDao.GroupID == groupId && p.Date == DateOnly.FromDateTime(date))
            .Select(p => new PresenceLocalEntity
            {
                Date = p.Date.ToDateTime(TimeOnly.MinValue),
                UserGuid = p.UserGuid,
                LessonNumber = p.LessonNumber,
                IsAttedance = p.IsAttedance
            })
            .ToList();
    }

    public void MarkUserAsAbsent(Guid userGuid, int firstLessonNumber, int lastLessonNumber)
    {
        foreach (var lesson in Enumerable.Range(firstLessonNumber, lastLessonNumber - firstLessonNumber + 1))
        {
            var presence = _remoteDatabaseContext.PresenceDaos.FirstOrDefault(p =>
                p.UserGuid == userGuid &&
                p.LessonNumber == lesson);

            if (presence != null)
            {
                presence.IsAttedance = false; 
            }
        }
    }

    public DateOnly? GetLastDateByGroupId(int groupId)
    {
       
        var lastDate = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserDao.GroupID == groupId)
            .OrderByDescending(p => p.Date)
            .Select(p => p.Date)
            .FirstOrDefault();

        return lastDate == default ? (DateOnly?)null : lastDate;
    }

    public GroupPresenceSummary GetGeneralPresenceForGroup(int groupId)
    {
        var presences = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserDao.GroupID == groupId)
            .OrderBy(p => p.Date).ThenBy(p => p.LessonNumber)
            .ToList();

        
        var distinctLessonDates = presences
            .Select(p => new { p.Date, p.LessonNumber })
            .Distinct()
            .ToList();

        int lessonCount = distinctLessonDates.Count;

      
        var userGuids = presences
            .Select(p => p.UserGuid)
            .Distinct()
            .ToHashSet();

        // Подсчитываем общее количество посещений и общее количество возможных посещений
        double totalAttendance = presences.Count(p => p.IsAttedance);
        double totalPossibleAttendance = userGuids.Count * lessonCount;

        var userAttendances = userGuids.Select(userGuid =>
        {
            var userPresences = presences.Where(p => p.UserGuid == userGuid).ToList();
            double attended = userPresences.Count(p => p.IsAttedance);
            double missed = userPresences.Count(p => !p.IsAttedance);

            return new UserAttendance
            {
                UserGuid = userGuid,
                Attended = attended,
                Missed = missed,
                AttendanceRate = (attended / (attended + missed)) * 100
            };
        }).ToList();

        // Рассчитываем общий процент посещаемости группы
        double totalAttendancePercentage = (totalAttendance / totalPossibleAttendance) * 100;

        return new GroupPresenceSummary
        {
            UserCount = userGuids.Count,
            LessonCount = lessonCount,
            TotalAttendancePercentage = totalAttendancePercentage,
            UserAttendances = userAttendances
        };
    }





    public void UpdateAtt(Guid UserGuid, int groupId, int firstLesson, int lastLesson, DateOnly date, bool isAttendance)
    {
        // Находим все записи по UserId, GroupId, LessonNumber (в диапазоне) и дате
        var presences = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserGuid == UserGuid
                        && p.UserDao.GroupID == groupId
                        && p.LessonNumber >= firstLesson
                        && p.LessonNumber <= lastLesson
                        && p.Date == date)
            .ToList();

        if (presences.Any())
        {
            // Обновляем значение IsAttendance для всех найденных записей
            foreach (var presence in presences)
            {
                presence.IsAttedance = isAttendance;
            }

            _remoteDatabaseContext.SaveChanges(); // Сохраняем изменения в базе данных
            Console.WriteLine($"Статус посещаемости для пользователя {UserGuid} с {firstLesson} по {lastLesson} урок обновлён.");
        }
        else
        {
            Console.WriteLine($"Посещаемость для пользователя ID: {UserGuid} на дату {date.ToShortDateString()} с {firstLesson} по {lastLesson} уроки не найдена.");
        }
    }
    public List<PresenceDao> GetAttendanceByGroup(int groupId)
    {
        // Получаем пользователей указанной группы
        var userGuidsInGroup = _remoteDatabaseContext.Users
            .Where(u => u.GroupID == groupId)
            .Select(u => u.Guid)
            .ToList();

        // Фильтруем посещаемость по пользователям из этой группы
        return _remoteDatabaseContext.PresenceDaos
            .Where(p => userGuidsInGroup.Contains(p.UserGuid))
            .Select(p => new PresenceDao
            {
                UserGuid = p.UserGuid,
                Id = p.Id,
                Date = p.Date,
                LessonNumber = p.LessonNumber,
                IsAttedance = p.IsAttedance
            })
            .ToList();
    }
}


