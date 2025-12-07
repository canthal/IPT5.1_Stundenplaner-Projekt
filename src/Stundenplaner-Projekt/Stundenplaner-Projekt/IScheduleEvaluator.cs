using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public interface IScheduleEvaluator
    {
        //List<Combination> Timetable { get; }

        //int OffPeakTime { get; }
        //int BetweenHours { get; }
        //int EfficientRoomUsing { get; }

        //int GetOffPeakTimeReduction();
        //int GetBetweenHoursReduction();
        //int GetEfficientRoomUsingReduction();
        int GetTotalScore(List<Combination> timetable);
    }
}
