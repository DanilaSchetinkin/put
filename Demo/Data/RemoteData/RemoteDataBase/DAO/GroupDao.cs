using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO
{
    public class GroupDao
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public IEnumerable<UserDao> Users { get; set; }

    }
}
