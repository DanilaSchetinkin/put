using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO
{
    public class PresenceDao
    {
        public required Guid UserGuid { get; set; }
        public bool IsAttedance { get; set; } = true;
        public DateOnly Date { get; set; }

        public int LessonNumber { get; set; }

        public UserDao UserDao { get; set; }
    }
}
