using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Interface für den Stundenplan Algorithmus
    /// </summary>
    public interface IScheduleGenerator
    {
        /// <summary>
        /// Klasse CurriculumValuation welcher alle Valuationen beinhaltet welcher Validiert werden soll
        /// </summary>
        CurriculumValuation CurriculumValuation { get; }
        /// <summary>
        /// Berechnet den kompletten Stundenplan von allen Klassen die eingegeben wurden 
        /// </summary>
        /// <returns>Gibt eine Liste aus allen Stundenplänen jeder Klasse wider</returns>
        List<Dictionary<TimeBlock, Combination>> GetBestPlan();
    }
}
