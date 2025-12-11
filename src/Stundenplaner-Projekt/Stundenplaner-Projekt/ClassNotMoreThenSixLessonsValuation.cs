using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Valuation Klasse welche prüft ob ein Stundenplan pro Tag mehr als sechs Stunden hat
    /// </summary>
    public class ClassNotMoreThenSixLessonsValuation : IScheduleEvaluator
    {
        /// <summary>
        /// Name der Klasse, welcher in Program benutzt werden kann
        /// </summary>
        public string Name { get; } = "ClassNotMoreThenSixLessonsValuation";

        /// <summary>
        /// Basis Value der Bewertung, von welcher Abgezogen wird bei ungenügender Erfüllung
        /// </summary>
        private const int BaseValue = 1000;

        /// <summary>
        /// Die Bestrafung welcher für die Valuation benutzt wird
        /// </summary>
        private int HigherThenSixLessonsValuation { get; }

        /// <summary>
        /// Konstruktor, nimmt ein Parameter an welcher freiwillig ist
        /// </summary>
        /// <param name="higherThenSixLessonsPunishment"></param>
        public ClassNotMoreThenSixLessonsValuation(int higherThenSixLessonsPunishment = 5)
        {
            HigherThenSixLessonsValuation = higherThenSixLessonsPunishment;
        }

        /// <summary>
        /// Berechnet, ob Stundenplan über sechs Stunden hat
        /// </summary>
        /// <param name="timetable">Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bestrafung zurück auf den BaseValue</returns>
        private int GetHigherSixLessonsValuation(List<Combination> timetable)
        {
            int value = 0;
            for (int i = 1; i <= 5; i++)
                value += GetValuationPerDay(timetable, (Weekday)i);
            return value;
        }

        /// <summary>
        /// Berechnet, ob pro Tag es mehr als sechs Lektionen hat. 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <param name="weekday">Der Tag welcher durchsucht wird</param>
        /// <returns></returns>
        private int GetValuationPerDay(List<Combination> timetable, Weekday weekday) => timetable.Count(t => t.Time.Day == weekday) > 6 ? HigherThenSixLessonsValuation : 0;

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetHigherSixLessonsValuation(timetable);
    }
}
