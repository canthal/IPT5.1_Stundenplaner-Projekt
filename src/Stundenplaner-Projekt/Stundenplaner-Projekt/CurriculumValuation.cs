using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class CurriculumValuation : IScheduleEvaluator
    {
        public string Name { get; } = "CurriculumValuation";
        private List<IScheduleEvaluator> ScheduleEvaluators { get; }

        public CurriculumValuation(List<IScheduleEvaluator> scheduleEvaluators)
        {
            ScheduleEvaluators = scheduleEvaluators;
        }

        public int GetTotalScore(List<Combination> timetable) => ScheduleEvaluators.Sum(s => s.GetTotalScore(timetable)) / ScheduleEvaluators.Count;
    }
}
