using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class MinimizeRoomChangeValuation : IScheduleEvaluator
    {
        public string Name { get; } = "MinimizeRoomChangeValuation";
        public int GetTotalScore(List<Combination> timetable)
        {
            return 0;
        }

    }
}
