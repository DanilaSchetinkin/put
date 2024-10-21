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
        private UserRepositoryImpl _repositoryUserImpl;
        private GroupRepositoryImpl _repositoryGroupImpl;

        public UserUseCase(UserRepositoryImpl repositoryImpl, GroupRepositoryImpl repositoryGroupImpl)
        {
            _repositoryUserImpl = repositoryImpl;
            _repositoryGroupImpl = repositoryGroupImpl;
        }

      public List<User> GetAllUsers() => _repositoryUserImpl.GetAllUsers
            .Join(_repositoryGroupImpl.GetAllGroups,
            user => user.GroupID,
            group => group.Id,
            (user, group) => 
            new User { FIO = user.FIO, 
                Guid = user.Guid, 
                Group = new Group {Id = group.Id, Name = group.Name } }
          ).ToList();

        

        public bool RemoveUserByGuid(Guid userGuid) {
           return _repositoryUserImpl.RemoveUserByGuid(userGuid);
        }
        public User UpdateUser(User user) {
            UserLocalEnity userLocalEnity = new UserLocalEnity { FIO = user.FIO, GroupID = user.Group.Id, Guid = user.Guid };
            UserLocalEnity? result = _repositoryUserImpl.UpdateUser(userLocalEnity);
            if (result == null) throw new Exception("");
            Group? group = GetAllGroups().FirstOrDefault(it => it.Id == result!.GroupID);
            if (group == null) throw new Exception("");
            return new User { FIO = user.FIO, Guid = user.Guid,  Group = group};
        }

        private List<Group> GetAllGroups() => _repositoryGroupImpl.GetAllGroups
                .Select(it => new Group { Id = it.Id, Name = it.Name }).ToList();
    }
}
