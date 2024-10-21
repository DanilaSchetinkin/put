using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.domain.Models
{
    internal class PresenceLocalEntity
    {
        public required Guid UserGuid { get; set; }
        public bool IsAttedance { get; set; } = true;
        public required DateOnly Date { get; set; }

        public required int LessonNumber { get; set; }
    }
}
