using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Klasse welches die gleichmässige Nutzung von Räumen bewertet
    /// </summary>
    public class EqualRoomUsingValuation : IScheduleEvaluator
    {
        /// <summary>
        /// Name der Klasse, welcher in Program benutzt werden kann
        /// </summary>
        public string Name { get; } = "EqualRoomUsingValuation";

        /// <summary>
        /// Basis Value der Bewertung, von welcher Abgezogen wird bei ungenügender Erfüllung
        /// </summary>
        public const int BaseValue = 1000;
        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        public int EqualRoomUsing { get; }

        /// <summary>
        /// Konstruktor, nimmt ein Parameter an welcher freiwillig ist
        /// </summary>
        public EqualRoomUsingValuation(int equalRoomUsingPunishment = 5)
        {
            EqualRoomUsing = equalRoomUsingPunishment;
        }

        /// <summary>
        /// Berechnet die Bestrafung bei Gleichmässiger Nutzung der Räume
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück</returns>
        private int GetEqualRoomUsingValuation(List<Combination> timetable)
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

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetEqualRoomUsingValuation(timetable);
    }
}
