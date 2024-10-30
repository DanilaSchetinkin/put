using Demo.Data.LocalData;
using Demo.Data.LocalData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository
{
    public class UserRepositoryImpl
    {
        public UserRepositoryImpl() {

            GetAllUsers = LocalStaticData.users;
        }
        public List<UserLocalEnity> GetAllUsers { get; set; }

        public bool RemoveUserByGuid(Guid userGuid)
        {
            UserLocalEnity? userLocal = GetAllUsers
                .Where(x => x.Guid == userGuid).FirstOrDefault();
            if (userLocal == null) return false;

            return GetAllUsers.Remove(userLocal);
        }

        public UserLocalEnity? GetUserByGuid(Guid userGuid) {
            UserLocalEnity? userLocal = GetAllUsers
                    .Where(x => x.Guid == userGuid).FirstOrDefault();
            if (userLocal == null) return null;

            return userLocal;
        }

        public UserLocalEnity? UpdateUser(UserLocalEnity userUpdateLocalEnity) {
            UserLocalEnity? userLocal = GetAllUsers
                    .Where(x => x.Guid == userUpdateLocalEnity.Guid).FirstOrDefault();
            if (userLocal == null) return null;
            userLocal.FIO = userUpdateLocalEnity.FIO;
            userLocal.GroupID = userUpdateLocalEnity.GroupID;
            return userLocal;

        }
    }
}
