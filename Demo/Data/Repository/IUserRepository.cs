using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository;

public interface IUserRepository
{
     List<UserLocalEnity> GetAllUser { get; set; }


    bool RemoveUserByGuid(Guid userGuid)
    {
        UserLocalEnity? userLocal = GetAllUser
            .Where(x => x.Guid == userGuid).FirstOrDefault();
        if (userLocal == null) return false;

        return GetAllUser.Remove(userLocal);
    }

    UserLocalEnity? GetUserByGuid(Guid userGuid)
    {
        UserLocalEnity? userLocal = GetAllUser
                .Where(x => x.Guid == userGuid).FirstOrDefault();
        if (userLocal == null) return null;

        return userLocal;
    }

    bool UpdateUser(UserLocalEnity newUser)
    {
        UserLocalEnity? userLocal = GetAllUser
                .Where(x => x.Guid == newUser.Guid).FirstOrDefault();
        if (userLocal == null) return false;
        userLocal.FIO = newUser.FIO;
        userLocal.GroupID = newUser.GroupID;
        return true;

    }
}
