using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase.DAO;
using Demo.Data.RemoteData.RemoteDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        _remoteDatabaseContext.PresenceDaos.AddRange(presences.Select(it => new PresenceDao
        {
            Date = DateOnly.FromDateTime(it.Date),
            IsAttedance = it.IsAttedance,
            LessonNumber = it.LessonNumber,
            UserGuid = it.UserGuid
        }));
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
        return _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserDao != null && p.UserDao.GroupID == groupId) // Проверяем на null перед использованием
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
                presence.IsAttedance = false; // Помечаем как отсутствующего
            }
        }
    }

    public DateOnly? GetLastDateByGroupId(int groupId)
    {
        // Проверяем наличие записей о посещаемости в базе данных для данной группы.
        var lastDate = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.GroupId == groupId)
            .OrderByDescending(p => p.Date)
            .Select(p => p.Date)
            .FirstOrDefault();

        return lastDate == default ? (DateOnly?)null : lastDate;
    }

    public void GetGeneralPresenceForGroup(int groupId)
    {
        var presences = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.GroupId == groupId)
            .OrderBy(p => p.LessonNumber)
            .ToList();

        var distinctDates = presences
            .Select(p => p.Date)
            .Distinct()
            .ToList();

        int lessonCount = 0;
        double totalAttendance = 0;
        DateOnly previousDate = DateOnly.MinValue;

        HashSet<Guid> userGuids = new HashSet<Guid>();

        foreach (var presence in presences)
        {
            userGuids.Add(presence.UserGuid);

            if (presence.Date != previousDate)
            {
                previousDate = presence.Date;
                lessonCount++;
            }

            if (presence.IsAttedance)
            {
                totalAttendance++;
            }
        }

        Console.WriteLine($"Человек в группе: {userGuids.Count}, " +
                          $"Количество проведённых занятий: {lessonCount}, " +
                          $"Общий процент посещаемости группы: {totalAttendance / (userGuids.Count * distinctDates.Count) * 100}%");

        // Подготовка для расчета посещаемости каждого пользователя
        List<UserAttendance> userAttendances = new List<UserAttendance>();

        foreach (var userGuid in userGuids)
        {
            var userPresences = presences.Where(p => p.UserGuid == userGuid);
            double attended = userPresences.Count(p => p.IsAttedance);
            double missed = userPresences.Count(p => !p.IsAttedance);

            userAttendances.Add(new UserAttendance
            {
                UserGuid = userGuid,
                Attended = attended,
                Missed = missed,
                AttendanceRate = attended / (attended + missed) * 100
            });
        }

        // Вывод информации по каждому пользователю
        foreach (var user in userAttendances)
        {
            if (user.AttendanceRate < 40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine($"GUID Пользователя: {user.UserGuid}, " +
                              $"Посетил: {user.Attended}, " +
                              $"Пропустил: {user.Missed}, " +
                              $"Процент посещаемости: {user.AttendanceRate}%");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }



    public void UpdateAtt(Guid UserGuid, int groupId, int firstLesson, int lastLesson, DateOnly date, bool isAttendance)
    {
        // Находим все записи по UserId, GroupId, LessonNumber (в диапазоне) и дате
        var presences = _remoteDatabaseContext.PresenceDaos
            .Where(p => p.UserGuid == UserGuid
                        && p.GroupId == groupId
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
}

