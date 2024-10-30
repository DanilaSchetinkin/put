using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.LocalData.Entity
{
    public class UserLocalEnity : IEquatable<UserLocalEnity>
    {
        public required string FIO { get; set; }
        public Guid Guid { get; set; }

        public required int GroupID { get; set; }



        public bool Equals(UserLocalEnity? other)
        {
            if (other == null) return false;
            return Guid.Equals(other.Guid);
        }
    }
}
