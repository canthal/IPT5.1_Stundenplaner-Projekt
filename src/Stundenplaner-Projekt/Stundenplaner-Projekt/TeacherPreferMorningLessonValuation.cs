using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    public class TeacherPreferMorningLessonValuation : IScheduleEvaluator
    {
        public string Name { get; } = "TeacherPreferMorningLessonValuation";
        public int GetTotalScore(List<Combination> timetable)
        {
            return 0;
        }
    }
}
