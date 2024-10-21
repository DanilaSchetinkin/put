using Demo.Data.LocalData;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Repository;

public class GroupRepositoryImpl
{
    //public List<GroupLocalEntity> GetAllGroups() => LocalStaticData.groups;

    public GroupRepositoryImpl()
    {

        GetAllGroups = LocalStaticData.groups;
    }


    public List<GroupLocalEntity> GetAllGroups { get; set; }






    public bool RemoveGroupById(int groupId)
    {
        GroupLocalEntity? groupLocal = GetAllGroups
            .FirstOrDefault(x => x.Id == groupId);
        if (groupLocal == null) return false;

        return GetAllGroups.Remove(groupLocal);
    }

    public GroupLocalEntity? UpdateGroup(GroupLocalEntity groupUpdateLocalEntity)
    {
        GroupLocalEntity? groupLocal = GetAllGroups
                .FirstOrDefault(x => x.Id == groupUpdateLocalEntity.Id);
        if (groupLocal == null) return null;
        groupLocal.Name = groupUpdateLocalEntity.Name;
        return groupLocal;

    }

    public GroupLocalEntity? AddGroup(GroupLocalEntity groupUpdateLocalEntity)
    {
        GroupLocalEntity? groupLocal = new GroupLocalEntity
        {
            Name = groupUpdateLocalEntity.Name,
            Id = GetAllGroups.OrderByDescending(g => g.Id).First().Id + 1
        };        

        GetAllGroups.Add(groupLocal); 
        return groupLocal;
    }
}




