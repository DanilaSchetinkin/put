using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.LocalData.Entity
{
    public class PresenceLocalEntity
    {
        public required Guid UserGuid { get; set; }
        public bool IsAttedance { get; set; } = true;
        public required DateTime Date { get; set; }

        public int GroupID { get; set; }

        public required int LessonNumber { get; set; }
    }
}
