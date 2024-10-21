using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository;

public interface IGroupRepository
{
    List<GroupLocalEntity> GetAllGroup { get; set; } 
    bool RemoveGroupById(int groupId);
    bool UpdateGroupById(int groupId, GroupLocalEntity updatedGroup)
    {
        GroupLocalEntity? groupLocal = GetAllGroup
                .FirstOrDefault(x => x.Id == updatedGroup.Id);
        if (groupLocal == null) return false;
        groupLocal.Name = updatedGroup.Name;
        return false;
    }
    GroupLocalEntity GetGroupById(int groupId);
    bool AddGroup(GroupLocalEntity newGroup)
    {
        GroupLocalEntity? groupLocal = new GroupLocalEntity
        {
            Name = newGroup.Name,
            Id = GetAllGroup.OrderByDescending(g => g.Id).First().Id + 1
        };

        GetAllGroup.Add(groupLocal);
        return true;
    }
}
