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

        public const int BaseValue = 1000;
        public int MinimizeRoomChange { get; }

        public MinimizeRoomChangeValuation(int minimizeRoomChange = 5)
        {
            MinimizeRoomChange = minimizeRoomChange;
        }

        public int GetMinimizeRoomChangeValuation(List<Combination> timetable)
        {
            int value = 0;
            for (int i = 0; i < timetable.Count - 1; i++)
            {
                string currRoom = timetable[i].Room.RoomId;
                if (timetable[i + 1].Room.RoomId == currRoom) continue;
                value += MinimizeRoomChange;
            }
            return value;
        }

        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetMinimizeRoomChangeValuation(timetable);

    }
}
