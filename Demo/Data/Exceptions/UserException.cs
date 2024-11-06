using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Exceptions
{
    public class UserException: RepositoryException
    {
        public UserException(Guid userGuid)
           : base($"Пользователь с GUID {userGuid} не найден.") { }
    }
}
