using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class EqualRoomUsingValuation : IScheduleEvaluator
    {
        public string Name { get; } = "EqualRoomUsingValuation";
        public int GetTotalScore(List<Combination> timetable)
        {
            throw new NotImplementedException();
        }
    }
}
