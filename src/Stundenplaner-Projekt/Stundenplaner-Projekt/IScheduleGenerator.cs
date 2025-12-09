using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public interface IScheduleGenerator
    {
        CurriculumValuation CurriculumValuation { get; }
        List<Dictionary<TimeBlock, Combination>> GetBestPlan();
    }
}
