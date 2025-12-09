using System;
using System.Collections.Generic;
using System.Linq;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Berechnet den Stundenplan welcher dann entgegen genommen werden kann von anderen Klassen
    /// </summary>
    public class CurriculumAlgo : IScheduleGenerator
    {
        /// <summary>
        /// Speicherung der Liste Fächer
        /// </summary>
        private List<Subject> _subjects;
        /// <summary>
        /// Speicherung der Liste Lehrer
        /// </summary>
        private List<Teacher> _teachers;
        /// <summary>
        /// Speicherung der Liste Schulklassen
        /// </summary>
        private List<SchoolClass> _schoolClasses;
        /// <summary>
        /// Speicherung der Liste Räume
        /// </summary>
        private List<Room> _rooms;

        /// <summary>
        /// Liste von Fächern wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Subject> Subjects
        {
            get => _subjects;
            private set
            {
                if (value.Count < 5) throw new Exception("Zu wenige Fächer eingereicht!");
                _subjects = value;
            }
        }
        /// <summary>
        /// Liste von Lehrer wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Teacher> Teachers
        {
            get => _teachers;
            private set
            {
                if (value.Count < 5) throw new Exception("Zu wenige Lehrer eingereicht!");
                _teachers = value;
            }
        }
        /// <summary>
        /// Liste von Fächern wird Räume, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Room> Rooms
        {
            get => _rooms;
            private set
            {
                if (value.Count < 5) throw new Exception("Zu wenige Räume eingereicht!");
                _rooms = value;
            }
        }
        /// <summary>
        /// Liste von Schulklasse wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<SchoolClass> SchoolClasses
        {
            get => _schoolClasses;
            private set
            {
                if (value.Count < 1) throw new Exception("Zu wenige Klassen eingereicht!");
                _schoolClasses = value;
            }
        }

        public CurriculumValuation CurriculumValuation { get; }

        /// <summary>
        /// Um den Algorithmus benutzen zu können, muss man erstmal es Instanziieren und alle Daten reinfüttern, bevor man es benutzen kann.
        /// </summary>
        /// <param name="schoolClasses">Liste aus allen Klassen</param>
        /// <param name="subjects">Liste aus den Fächern die verwendet werden sollen</param>
        /// <param name="teachers">Liste von jedem aktiven Lehrer</param>
        /// <param name="rooms">Liste aus allen betriebsbereiten Räumen</param>
        public CurriculumAlgo(List<SchoolClass> schoolClasses, List<Subject> subjects, List<Teacher> teachers, List<Room> rooms, CurriculumValuation curriculumValuation)
        {
            SchoolClasses = schoolClasses;
            Subjects = subjects;
            Teachers = teachers;
            Rooms = rooms;
            CurriculumValuation = curriculumValuation;
        }

        /// <summary>
        /// Berechnet jede Zeit für jeden Tag
        /// </summary>
        /// <returns>Gibt eine Liste aus für jeden Stunde pro Tag (Montag - Freitag)</returns>
        private List<TimeBlock> GetCurricullumTime()
        {
            List<TimeBlock> timetable = new();
            for (int i = 1; i <= 5; i++)
                for (int j = 0; j < WorkHours; j++)
                    timetable.Add(new TimeBlock((Weekday)i, j));
            return timetable;
        }

        /// <summary>
        /// Erstellt eine Liste aus allen logischen möglichen Kombinationen welche existieren können (Matrix)
        /// </summary>
        /// <returns>Gibt eine Liste aus allen möglichen Kombinationen wider</returns>
        private List<Combination> GetCombinationMatrix()
        {
            var allComb =
                from time in GetCurricullumTime()
                from subject in Subjects
                from teacher in Teachers
                where teacher.TeachingSubjects.Any(s => s.Name == subject.Name) && teacher.AvailableBlocks.Any(t => t.Day == time.Day && t.BlockIndex == time.BlockIndex)
                from room in Rooms
                select new Combination(subject, teacher, room, time);
            return allComb.ToList();
        }

        /// <summary>
        /// Generiert einen zufälligen Stundenplan für alle Tage für jede Klasse basierend auf der Matrix die davor generiert wurde.
        /// </summary>
        /// <returns>Gibt alle Stundenpläne aus für jede Schulklasse</returns>
        private List<Dictionary<TimeBlock, Combination>> GetRandomCurriculum()
        {
            List<Dictionary<TimeBlock, Combination>> allCurr = new();
            Random rnd = new();
            List<Combination> allCombinations = GetCombinationMatrix();
            foreach (var schoolClass in SchoolClasses)
            {
                Dictionary<TimeBlock, Combination> tempComb = new();
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        if (allCombinations.Count == 0) throw new Exception("Keine Kombinationen mehr verfügbar!");

                        TimeBlock timeBlock;
                        Combination combination;
                        do
                        {
                            combination = allCombinations[rnd.Next(0, allCombinations.Count)];
                            timeBlock = new TimeBlock((Weekday)i, combination.Time.BlockIndex);
                        } while (tempComb.Keys.Any(time => ((time.BlockIndex == timeBlock.BlockIndex) && (time.Day == timeBlock.Day))));
                        tempComb.Add(timeBlock, combination);

                        allCombinations.RemoveAll(e => e.Teacher.FirstName == combination.Teacher.FirstName && e.Teacher.LastName == combination.Teacher.LastName && e.Time.Day == combination.Time.Day && e.Time.BlockIndex == combination.Time.BlockIndex);
                    }
                }
                allCurr.Add(tempComb);
            }
            return allCurr;
        }

        /// <summary>
        /// Generiert auf Heuristischer Methode den nahezu besten Stundenplan auf zufallsbasierter Erstellung
        /// </summary>
        /// <returns>Gibt den nahezu besten Stundenplan aus in einem Dictionary für jede Schulklasse und Tag</returns>
        public List<Dictionary<TimeBlock, Combination>> GetBestPlan()
        {
            List<Dictionary<TimeBlock, Combination>> curriculums = new();

            int bestScore = 0;
            for (int i = 0; i < 500; i++)
            {
                List<Dictionary<TimeBlock, Combination>> currList = GetRandomCurriculum();
                int avgVal = 0;
                foreach (var cur in currList)
                    avgVal += CurriculumValuation.GetTotalScore(cur.Values.ToList());
                avgVal /= currList.Count;

                if (avgVal > bestScore)
                {
                    curriculums = currList;
                    bestScore = avgVal;
                }
            }

            List<Dictionary<TimeBlock, Combination>> tempDic = new();
            for (int i = 0; i < curriculums.Count; i++)
            {
                if (SchoolClasses[i].Timetable == null) SchoolClasses[i].Timetable = new Dictionary<TimeBlock, Combination>();

                Dictionary<TimeBlock, Combination> sortedDic = new();
                foreach (var t in curriculums[i].OrderBy(k => k.Key.Day).ThenBy(k => k.Key.BlockIndex))
                    sortedDic.Add(t.Key, new Combination(t.Value.Subject, t.Value.Teacher, t.Value.Room, t.Key));
                SchoolClasses[i].Timetable.Clear();
                foreach (var s in sortedDic)
                    SchoolClasses[i].Timetable.Add(s.Key, s.Value);
                tempDic.Add(sortedDic);
            }
            curriculums = tempDic;
            return curriculums;
        }
    }
}
