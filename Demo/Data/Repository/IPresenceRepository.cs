using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase.DAO;
using Demo.Data.Repository;
using System;
using System.Collections.Generic;

namespace Demo.Data.Repository
{
    public interface IPresenceRepository
    {
        void SavePresence(List<PresenceLocalEntity> presences);
        List<PresenceLocalEntity> GetPresenceByGroup(int groupId);
        List<PresenceLocalEntity> GetPresenceByGroupAndDate(int groupId, DateTime date);
        void MarkUserAsAbsent(Guid userGuid, int groupId, int firstLessonNumber, int lastLessonNumber);
        void AddPresence(PresenceLocalEntity presence);



        void SavePresenceDaos(List<PresenceDao> presences);
        List<PresenceDao> GetPresenceByGroupDaos(int groupId);
        List<PresenceDao> GetPresenceByGroupAndDateDaos(int groupId, DateTime date);
        void MarkUserAsAbsentDaos(Guid userGuid, int groupId, int firstLessonNumber, int lastLessonNumber);
        void AddPresenceDaos(PresenceDao presence);


    }
}
