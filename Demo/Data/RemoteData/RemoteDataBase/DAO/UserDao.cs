using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO;

public class UserDao
{
    public required string FIO { get; set }

    public Guid Guid { get; set; }

    public required int GroupID { get; set; }

    public GroupDao Group { get; set; }
}
