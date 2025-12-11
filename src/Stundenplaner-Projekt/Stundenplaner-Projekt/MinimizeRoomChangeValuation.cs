using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class MinimizeRoomChangeValuation : IScheduleEvaluator
    {
        /// <summary>
        /// Name der Klasse, welcher in Program benutzt werden kann
        /// </summary>
        public string Name { get; } = "MinimizeRoomChangeValuation";

        /// <summary>
        /// Basis Value der Bewertung, von welcher Abgezogen wird bei ungenügender Erfüllung
        /// </summary>
        private const int BaseValue = 1000;
        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        private int MinimizeRoomChange { get; }
        /// <summary>
        /// Konstruktor, nimmt ein Parameter an welcher freiwillig ist
        /// </summary>
        public MinimizeRoomChangeValuation(int minimizeRoomChange = 5)
        {
            MinimizeRoomChange = minimizeRoomChange;
        }

        /// <summary>
        /// Berechnet die Bestrafung bei Minimaler Raumwechseln
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück</returns>
        private int GetMinimizeRoomChangeValuation(List<Combination> timetable)
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

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetMinimizeRoomChangeValuation(timetable);

    }
}
