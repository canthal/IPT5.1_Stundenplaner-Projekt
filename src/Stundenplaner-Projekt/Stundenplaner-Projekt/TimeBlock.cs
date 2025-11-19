using System;

namespace Stundenplaner_Projekt
{
    public class TimeBlock
    {
        public enum Weekday { Montag = 1, Dienstag = 2, Mittwoch = 3, Donnerstag = 4, Freitag = 5 }

        private readonly static string[] Hours =
        {
            "8:00 - 9:00",
            "9:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "15:00 - 16:00",
            "16:00 - 17:00"
        };

        public static int WorkHours { get; } = Hours.Length;
        public Weekday Day { get; }
        public int BlockIndex { get; }
        public string GetHours => Hours[BlockIndex];

        //public int GetBlockIndex(string hour) => Array.IndexOf(Hours, hour);

        public TimeBlock(Weekday weekday)
        {
            Day = weekday;
        }

        public TimeBlock(Weekday weekday, int blockIndex) : this(weekday)
        {
            BlockIndex = blockIndex;
        }
    }
}
