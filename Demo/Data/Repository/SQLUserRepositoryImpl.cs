using Demo.Data.Exceptions;
using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository;

public class SQLUserRepositoryImpl: IUserRepository
{
    private readonly RemoteDatabaseContext _remoteDatabaseContext;

    public SQLUserRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
    {
        _remoteDatabaseContext = remoteDatabaseContext;
    }

    
    public IEnumerable<UserLocalEnity> GetAllUsers => _remoteDatabaseContext.Users
        .Select(u => new UserLocalEnity
        {
            Guid = u.Guid,
            FIO = u.FIO,
            GroupID = u.GroupID
        })
        .ToList();

    
    public bool RemoveUserById(Guid userGuid)
    {
        var user = _remoteDatabaseContext.Users.FirstOrDefault(u => u.Guid == userGuid);
        if (user == null) throw new UserException(userGuid);

        _remoteDatabaseContext.Users.Remove(user);
        _remoteDatabaseContext.SaveChanges(); 
        return true;
    }

   
    public UserLocalEnity? UpdateUser(UserLocalEnity user)
    {
        var existingUser = _remoteDatabaseContext.Users.FirstOrDefault(u => u.Guid == user.Guid);
        if (existingUser == null) throw new UserException(user.Guid);

        existingUser.FIO = user.FIO;
        existingUser.GroupID = user.GroupID;
        _remoteDatabaseContext.SaveChanges(); 

       
        return new UserLocalEnity
        {
            Guid = existingUser.Guid,
            FIO = existingUser.FIO,
            GroupID = existingUser.GroupID
        };
    }

    
    public IEnumerable<RemoteData.RemoteDataBase.DAO.UserDao> GetAllUsersDao => _remoteDatabaseContext.Users.ToList();




    public List<UserLocalEnity> GetAllUser
    {
        get => _remoteDatabaseContext.Users
        .Select(u => new UserLocalEnity
        {
            Guid = u.Guid,
            FIO = u.FIO,
            GroupID = u.GroupID
        })
        .ToList();
        set => GetAllUser = value;
    }

    //public List<UserLocalEnity>. GetAllUser(UserLocalEnity user)
    //{

    //    return _iRepositoryUser.GetAllUser
    //        .Join(_iRepositoryGroup.GetAllGroup,
    //            user => user.GroupID,
    //            group => group.Id,
    //            (user, group) => new UserLocalEntity
    //            {
    //                FIO = user.FIO,
    //                Guid = user.Guid,
    //                Group = new Group { Id = group.Id, Name = group.Name }
    //            })
    //        .ToList();

    //}




    //    { return _iRepositoryUser.GetAllUser
    //            .Join(_iRepositoryGroup.GetAllGroup,
    //                user => user.GroupID,
    //                group => group.Id,
    //                (user, group) => new UserLocalEntity
    //                {
    //                    FIO = user.FIO,
    //                    Guid = user.Guid,
    //                    Group = new Group { Id = group.Id, Name = group.Name
    //}
    //                })
    //            .ToList(); }


    //_iRepositoryUser.GetAllUser
    //            .Join(_iRepositoryGroup.GetAllGroup,
    //            user => user.GroupID,
    //            group => group.Id,
    //            (user, group) =>
    //            new User
    //            {
    //                FIO = user.FIO,
    //                Guid = user.Guid,
    //                Group = new Group { Id = group.Id, Name = group.Name }
    //            }
    //          ).ToList();


}

