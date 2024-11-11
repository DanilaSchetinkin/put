using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO;

public class Execel
{
    public Guid UserGuid { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public DateOnly Date { get; set; }
    public bool IsAttedance { get; set; }
    public int LessonNumber { get; set; }
    public string GroupName { get; set; }

}
