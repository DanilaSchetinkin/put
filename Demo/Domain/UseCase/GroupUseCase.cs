using Demo.Data.Repository;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.UseCase;

public class GroupUseCase
{
    private IGroupRepository _iRepositoryGroup;


    public GroupUseCase(IGroupRepository iRepositoryGroup)
    {

        _iRepositoryGroup = iRepositoryGroup;
    }


    public List<Group> GetAllGroup() => _iRepositoryGroup.GetAllGroup
                .Select(it => new Group { Id = it.Id, Name = it.Name }).ToList();


    public bool RemoveGroupById(int groupId) => _iRepositoryGroup.RemoveGroupById(groupId);
        

    public Group UpdateGroupById(int groupId ,GroupLocalEntity updatedGroup)
    {
        GroupLocalEntity groupLocalEntity = new GroupLocalEntity { Id = updatedGroup.Id, Name = updatedGroup.Name };
        bool result = _iRepositoryGroup.UpdateGroupById(groupId, groupLocalEntity);
        if (!result) throw new Exception("");
        return new Group { Id = groupLocalEntity.Id, Name = groupLocalEntity.Name };
    }



    public Group AddGroup(GroupLocalEntity newGroup)
    {
        GroupLocalEntity groupLocalEntity = new GroupLocalEntity { Id = newGroup.Id, Name = newGroup.Name };
        bool result = _iRepositoryGroup.AddGroup(newGroup);
        if (!result) throw new Exception("");
        return new Group { Id = newGroup.Id, Name = newGroup.Name };
    }


    public Group GetGroupById(int groupId)
    {
        
        GroupLocalEntity? groupLocalEntity = _iRepositoryGroup.GetGroupById(groupId);

        
        if (groupLocalEntity == null)
        {
            throw new Exception("");
        }

        
        return new Group { Id = groupLocalEntity.Id, Name = groupLocalEntity.Name };
    }
}
