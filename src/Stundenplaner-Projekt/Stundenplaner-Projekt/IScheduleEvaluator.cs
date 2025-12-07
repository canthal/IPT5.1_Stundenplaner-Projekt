using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public interface IScheduleEvaluator
    {
        string Name { get; }
        int GetTotalScore(List<Combination> timetable);
    }
}
