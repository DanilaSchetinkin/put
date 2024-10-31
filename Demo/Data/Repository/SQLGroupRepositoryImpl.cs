using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Data.LocalData.Entity;
using Demo.Data.RemoteData.RemoteDataBase;

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
}
