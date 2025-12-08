using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    public class OffPeak_BetweenHours_EfficientRoomUsingValuation : IScheduleEvaluator
    {

        public const int BaseValue = 1000;
        public string Name { get; } = "BasicValuation";
        public int OffPeakTime { get; }
        public int BetweenHours { get; }
        public int EfficientRoomUsing { get; }

        public OffPeak_BetweenHours_EfficientRoomUsingValuation(int offPeakTime = 5, int betweenHours = 5, int efficientRoomUsing = 5)
        {
            OffPeakTime = offPeakTime;
            BetweenHours = betweenHours;
            EfficientRoomUsing = efficientRoomUsing;
        }

        public int GetOffPeakTimeReduction(List<Combination> timetable) => timetable.Where(t => ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == WorkHours - 1))).Count() * OffPeakTime;
        
        public int GetBetweenHoursReduction(List<Combination> timetable)
        {
            int value = 0;
            HashSet<string> memorizeRooms = new();
            foreach (var t in timetable)
            {
                if (!memorizeRooms.Contains(t.Room.RoomId))
                    memorizeRooms.Add(t.Room.RoomId);
                else
                    value += EfficientRoomUsing;
            }
            return value;
        }
        public int GetEfficientRoomUsingReduction(List<Combination> timetable)
        {
            int value = 0;
            int firstHour = int.MaxValue;
            foreach (var item in timetable)
                if (item.Time.BlockIndex < firstHour)
                    firstHour = item.Time.BlockIndex;

            for (int i = firstHour; i < WorkHours - 1; i++)
            {
                bool isValue = false;
                foreach (var item in timetable)
                {
                    if (item.Time.BlockIndex == i)
                    {
                        isValue = true;
                        break;
                    }
                }
                if (!isValue) value += BetweenHours;
            }
            return value;
        }

        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetOffPeakTimeReduction(timetable) - GetBetweenHoursReduction(timetable) - GetEfficientRoomUsingReduction(timetable);
    }
}
