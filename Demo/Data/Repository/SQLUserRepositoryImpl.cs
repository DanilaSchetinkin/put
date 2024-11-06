using Demo.Data.Exceptions;
using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase;
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

    // Метод для получения всех пользователей
    public IEnumerable<UserLocalEnity> GetAllUsers => _remoteDatabaseContext.Users
        .Select(u => new UserLocalEnity
        {
            Guid = u.Guid,
            FIO = u.FIO,
            GroupID = u.GroupID
        })
        .ToList();

    // Метод для удаления пользователя по GUID
    public bool RemoveUserById(Guid userGuid)
    {
        var user = _remoteDatabaseContext.Users.FirstOrDefault(u => u.Guid == userGuid);
        if (user == null) throw new UserException(userGuid);

        _remoteDatabaseContext.Users.Remove(user);
        _remoteDatabaseContext.SaveChanges(); // Сохранение изменений в базе данных
        return true;
    }

    // Метод для обновления данных пользователя
    public UserLocalEnity? UpdateUser(UserLocalEnity user)
    {
        var existingUser = _remoteDatabaseContext.Users.FirstOrDefault(u => u.Guid == user.Guid);
        if (existingUser == null) throw new UserException(user.Guid);

        existingUser.FIO = user.FIO;
        existingUser.GroupID = user.GroupID;
        _remoteDatabaseContext.SaveChanges(); // Сохранение изменений в базе данных

        // Возвращаем обновленный объект UserLocalEnity
        return new UserLocalEnity
        {
            Guid = existingUser.Guid,
            FIO = existingUser.FIO,
            GroupID = existingUser.GroupID
        };
    }

    // Дополнительный метод для DAO, если требуется
    public IEnumerable<RemoteData.RemoteDataBase.DAO.UserDao> GetAllUsersDao => _remoteDatabaseContext.Users.ToList();

    public List<UserLocalEnity> GetAllUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

