using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Interface für Valuationen 
    /// </summary>
    public interface IScheduleEvaluator
    {
        /// <summary>
        /// Name der Klasse
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Berechnet die Insgesamte Bewertung eines Stundenplanes 
        /// </summary>
        /// <param name="timetable">Der Stundenplan einer Klasse</param>
        /// <returns>Gibt die Bewertung der Klasse zurück</returns>
        int GetTotalScore(List<Combination> timetable);
    }
}
