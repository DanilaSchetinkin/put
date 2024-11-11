using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO
{
    public class PresenceDao
    {
        [Key]
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public bool IsAttedance { get; set; } = true;
        public DateOnly Date { get; set; }

        public int LessonNumber { get; set; }

        public virtual UserDao? UserDao { get; set; }
        
    }
}
