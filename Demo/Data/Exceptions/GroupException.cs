using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Exceptions
{
    public class GroupException : RepositoryException
    {
        public GroupException(int groupId)
           : base($"Группа с ID {groupId} не найдена.") { }
    }
}
