using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.RemoteData.RemoteDataBase.DAO;

public class UserAttendance
{
    public Guid UserGuid { get; set; }
    public double Attended { get; set; }
    public double Missed { get; set; }
    public double AttendanceRate { get; set; }
}

public class GroupPresenceSummary
{
    public int UserCount { get; set; }
    public int LessonCount { get; set; }
    public double TotalAttendancePercentage { get; set; }
    public List<UserAttendance> UserAttendances { get; set; }
}
