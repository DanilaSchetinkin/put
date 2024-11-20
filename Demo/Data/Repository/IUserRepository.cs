using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository;

public interface IUserRepository
{
     List<UserLocalEnity> GetAllUser { get; set; }


    async Task<bool> RemoveUserByGuid(Guid userGuid)
    {
        using var context = new RemoteDatabaseContext();
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Guid == userGuid);

        if (user == null) 
            return false;

        try
        {
            context.Users.Remove(user);
            return await context.SaveChangesAsync() == 1;
        }
        catch
        {
            return false;
        }
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
