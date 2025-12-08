using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    public class ClassNotMoreThenSixLessonsValuation : IScheduleEvaluator
    {
        public string Name { get; } = "ClassNotMoreThenSixLessonsValuation";

        public const int BaseValue = 1000;
        public int HigherThenSixLessons { get; }

        public ClassNotMoreThenSixLessonsValuation(int higherThenSixLessons)
        {
            HigherThenSixLessons = higherThenSixLessons;
        }

        public int GetHigherSixLessonsValuation(List<Combination> timetable)
        {
            int value = 0;
            for (int i = 1; i <= 5; i++)
                value += GetValuationPerDay(timetable, (Weekday)i);
            return value;
        }

        private int GetValuationPerDay(List<Combination> timetable, Weekday weekday) => timetable.Count(t => t.Time.Day == weekday) > 6 ? HigherThenSixLessons : 0;

        public int GetTotalScore(List<Combination> timetable) => BaseValue - GetHigherSixLessonsValuation(timetable);
    }
}
