using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class ClassNotMoreThenSixLessonsValuation : IScheduleEvaluator
    {
        public string Name { get; } = "ClassNotMoreThenSixLessonsValuation";
        public int GetTotalScore(List<Combination> timetable)
        {
            return 0;
        }
    }
}
