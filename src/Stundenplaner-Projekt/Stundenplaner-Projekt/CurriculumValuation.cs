using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Klasse welcher im Stundenplan Algorithmus verwendet wird, welcher alle benötigten Valuationen beinhaltet
    /// </summary>
    public class CurriculumValuation : IScheduleEvaluator
    {
        /// <summary>
        /// Name der Klasse
        /// </summary>
        public string Name { get; } = "CurriculumValuation";

        /// <summary>
        /// Alle Valuationen welche benötigt sind in einer Liste (schreibgeschützt)
        /// </summary>
        private List<IScheduleEvaluator> ScheduleEvaluators { get; }

        /// <summary>
        /// Konstruktor CurriculumValuation, welcher einen Parameter annimmt.
        /// </summary>
        /// <param name="scheduleEvaluators">Alle Valuationen die gebraucht werden</param>
        public CurriculumValuation(List<IScheduleEvaluator> scheduleEvaluators)
        {
            ScheduleEvaluators = scheduleEvaluators;
        }

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        public int GetTotalScore(List<Combination> timetable) => ScheduleEvaluators.Sum(s => s.GetTotalScore(timetable)) / ScheduleEvaluators.Count;
    }
}
