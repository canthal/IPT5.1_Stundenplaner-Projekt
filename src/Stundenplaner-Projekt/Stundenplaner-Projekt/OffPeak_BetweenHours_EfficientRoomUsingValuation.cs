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
        /// <summary>
        /// Basis Value der Bewertung, von welcher Abgezogen wird bei ungenügender Erfüllung
        /// </summary>
        private const int BaseValue = 1000;
        /// <summary>
        /// Name der Klasse, welcher in Program benutzt werden kann
        /// </summary>
        public string Name { get; } = "BasicValuation";
        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        private int OffPeakTime { get; }
        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        private int BetweenHours { get; }
        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        private int EfficientRoomUsing { get; }

        /// <summary>
        /// Konstruktor, nimmt ein Parameter an welcher freiwillig ist
        /// </summary>
        public OffPeak_BetweenHours_EfficientRoomUsingValuation(int offPeakTime = 5, int betweenHours = 5, int efficientRoomUsing = 5)
        {
            OffPeakTime = offPeakTime;
            BetweenHours = betweenHours;
            EfficientRoomUsing = efficientRoomUsing;
        }

        /// <summary>
        /// Berechnet die Bestrafung bei Randstunden
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück</returns>
        private int GetOffPeakTimeReduction(List<Combination> timetable) => timetable.Where(t => ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == WorkHours - 1))).Count() * OffPeakTime;

        /// <summary>
        /// Berechnet die Bestrafung bei Zwischenstunden
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück</returns>
        private int GetBetweenHoursReduction(List<Combination> timetable)
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

        /// <summary>
        /// Berechnet die Bestrafung bei Effiziente Nutzung der Räume
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück</returns>
        private int GetEfficientRoomUsingReduction(List<Combination> timetable)
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

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetOffPeakTimeReduction(timetable) - GetBetweenHoursReduction(timetable) - GetEfficientRoomUsingReduction(timetable);
    }
}
