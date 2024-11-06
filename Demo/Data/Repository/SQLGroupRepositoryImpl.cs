using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase;
using Demo.Data.RemoteData.RemoteDataBase.DAO;

namespace Demo.Data.Repository;

 public class SQLGroupRepositoryImpl:IGroupRepository
{
    private readonly RemoteDatabaseContext _remoteDatabaseContext;
    

    public SQLGroupRepositoryImpl(RemoteDatabaseContext remoteDatabaseContext)
    {
        _remoteDatabaseContext =  remoteDatabaseContext;
    }

    public List<GroupLocalEntity> GetAllGroup { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


     public GroupLocalEntity? GetGroupById(int groupId)
    {
        var groupDao = _remoteDatabaseContext.Groups.FirstOrDefault(g => g.Id == groupId);
        return groupDao != null ? new GroupLocalEntity { Id = groupDao.Id, Name = groupDao.Name } : null;
    }

    public List<GroupLocalEntity> AllGroup => _remoteDatabaseContext.Groups
            .Select(g => new GroupLocalEntity { Id = g.Id, Name = g.Name })
            .ToList();


    public bool AddGroup(GroupLocalEntity group)
    {
        if (_remoteDatabaseContext.Groups.Any(g => g.Id == group.Id))
            return false;

        var groupDao = new GroupDao { Id = group.Id, Name = group.Name };
        _remoteDatabaseContext.Groups.Add(groupDao);
        _remoteDatabaseContext.SaveChanges();
        return true;
    }

   
    public bool UpdateGroupById(int groupID, GroupLocalEntity updatedGroup)
    {
        var existingGroup = _remoteDatabaseContext.Groups.FirstOrDefault(g => g.Id == groupID);
        if (existingGroup == null)
            return false;

        existingGroup.Name = updatedGroup.Name;
        _remoteDatabaseContext.SaveChanges();
        return true;
    }

   
    public bool RemoveGroupById(int groupID)
    {
        var existingGroup = _remoteDatabaseContext.Groups.FirstOrDefault(g => g.Id == groupID);
        if (existingGroup == null)
            return false;

        _remoteDatabaseContext.Groups.Remove(existingGroup);
        _remoteDatabaseContext.SaveChanges();
        return true;
    }

}
