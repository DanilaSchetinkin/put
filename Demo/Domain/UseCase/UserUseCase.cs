using Demo.Data.LocalData.Entity;
using Demo.Data.Repository;
using Demo.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.UseCase
{
    public class UserUseCase
    {
        private IUserRepository _iRepositoryUser;
        private IGroupRepository _iRepositoryGroup;
        private UserRepositoryImpl userRepositoryImpl;
        private GroupRepositoryImpl groupRepositoryImpl;

        public UserUseCase(IUserRepository iRepositoryUser, IGroupRepository iRepositoryGroup)
        {
            _iRepositoryUser = iRepositoryUser;
            _iRepositoryGroup = iRepositoryGroup;
        }

        public UserUseCase(UserRepositoryImpl userRepositoryImpl, GroupRepositoryImpl groupRepositoryImpl)
        {
            this.userRepositoryImpl = userRepositoryImpl;
            this.groupRepositoryImpl = groupRepositoryImpl;
        }

        public List<User> GetAllUsers() => _iRepositoryUser.GetAllUser
            .Join(_iRepositoryGroup.GetAllGroup,
            user => user.GroupID,
            group => group.Id,
            (user, group) => 
            new User { FIO = user.FIO, 
                Guid = user.Guid, 
                Group = new Group {Id = group.Id, Name = group.Name } }
          ).ToList();

        private List<Group> GetAllGroup() => _iRepositoryGroup.GetAllGroup
                .Select(it => new Group { Id = it.Id, Name = it.Name }).ToList();

        public bool RemoveUserByGuid(Guid userGuid) {
           return _iRepositoryUser.RemoveUserByGuid(userGuid);
        }
        public User UpdateUser(User user) {
            UserLocalEnity userLocalEnity = new UserLocalEnity { FIO = user.FIO, GroupID = user.Group.Id, Guid = user.Guid };
            bool result = _iRepositoryUser.UpdateUser(userLocalEnity);
            if (!result)
                throw new InvalidOperationException("");

            var groups = GetAllGroup();
            if (groups == null || !groups.Any())
                throw new InvalidOperationException("");

            Group? group = groups.FirstOrDefault(it => it.Id == userLocalEnity.GroupID);
            if (group == null)
                throw new InvalidOperationException("");

            return new User { FIO = user.FIO, Guid = user.Guid, Group = group };
        }

        
    }
}
