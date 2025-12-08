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

        public const int BaseValue = 1000;
        public int EqualRoomUsing { get; }

        public EqualRoomUsingValuation(int equalRoomUsing)
        {
            EqualRoomUsing = equalRoomUsing;
        }

        public int GetEqualRoomUsingValuation(List<Combination> timetable)
        {
            int value = 0;
            List<Room> allRooms = new();
            foreach (var time in timetable)
                allRooms.Add(time.Room);

            HashSet<int> roomUsing = new();
            for (int i = 0; i < allRooms.Count; i++)
            {
                Room searchRoon = allRooms[i];
                int count = 0;
                foreach (var room in allRooms)
                    if (searchRoon.RoomId == room.RoomId)
                        count++;
                roomUsing.Add(count);
            }

            foreach (int room in roomUsing)
                if (room < 3) value += EqualRoomUsing;

            return value;
        }

        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetEqualRoomUsingValuation(timetable);
    }
}
