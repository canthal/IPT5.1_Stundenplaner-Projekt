using System;
using System.Collections.Generic;
using System.Linq;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Berechnet den Stundenplan welcher dann entgegen genommen werden kann von anderen Klassen
    /// </summary>
    internal class CurriculumAlgo
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

        private int _countPeakOffTime = 0;
        private int _countBetweenTime = 0;
        private int _countEfficiency = 0;
        public int CountPeakOffTime { get => _countPeakOffTime; private set { _countPeakOffTime = value; } }
        public int CountBetweenTime { get => _countBetweenTime; private set { _countBetweenTime = value; } }
        public int CountEfficiency { get => _countEfficiency; private set { _countEfficiency = value; } }

        /// <summary>
        /// Liste von Fächern wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Subject> Subjects
        {
            get => _subjects;
            private set => _subjects = value;
        }
        /// <summary>
        /// Liste von Lehrer wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Teacher> Teachers
        {
            get => _teachers;
            private set => _teachers = value;
        }
        /// <summary>
        /// Liste von Fächern wird Räume, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<Room> Rooms
        {
            get => _rooms;
            private set => _rooms = value;
        }
        /// <summary>
        /// Liste von Schulklasse wird verwendet, um für interne Methoden wie Matrix erstellung die einzelnen Fächer zur verfügung zu stellen
        /// </summary>
        internal List<SchoolClass> SchoolClasses
        {
            get => _schoolClasses;
            private set => _schoolClasses = value;
        }

        /// <summary>
        /// Um den Algorithmus benutzen zu können, muss man erstmal es Instanziieren und alle Daten reinfüttern, bevor man es benutzen kann.
        /// </summary>
        /// <param name="schoolClasses">Liste aus allen Klassen</param>
        /// <param name="subjects">Liste aus den Fächern die verwendet werden sollen</param>
        /// <param name="teachers">Liste von jedem aktiven Lehrer</param>
        /// <param name="rooms">Liste aus allen betriebsbereiten Räumen</param>
        internal CurriculumAlgo(List<SchoolClass> schoolClasses,List<Subject> subjects, List<Teacher> teachers, List<Room> rooms)
        {
            SchoolClasses = schoolClasses;
            Subjects = subjects;
            Teachers = teachers;
            Rooms = rooms;
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
                where teacher.TeachingSubjects.Any(s => s.Name == subject.Name) && teacher.AvailableBlocks.Any(t => t.Day == time.Day) && teacher.AvailableBlocks.Any(t => t.BlockIndex == time.BlockIndex)
                from room in Rooms
                select new Combination(subject, teacher, room, time);
            return allComb.ToList();
        }

        /// <summary>
        /// Berechnet pro Stundenplan pro Klasse eine Bewertung, basierend auf Randzeiten, Zwischenstunden und Effizients von der Nutzung der Zimmer.
        /// </summary>
        /// <param name="timetable">Einspeisung eines Stundenplanes einer Klasse</param>
        /// <param name="offPeakTime">Gewichtung der Randzeiten</param>
        /// <param name="betweenHours">Gewichtung der Zwischenstunden</param>
        /// <param name="efficientRoomUsing">Gewichtung der effizients der Raumnutzung</param>
        /// <returns></returns>
        private int GetValuation(List<Combination> timetable, int offPeakTime = 5, int betweenHours = 5, int efficientRoomUsing = 20)
        {
            int value = 1000;
            HashSet<string> memorizeRooms = new(); 
            foreach (var t in timetable)
            {
                if ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == WorkHours - 1))
                {
                    value -= offPeakTime;
                    CountPeakOffTime++;
                }
                if (!memorizeRooms.Any(m => m == t.Room.RoomId))
                    memorizeRooms.Add(t.Room.RoomId);
                else
                {
                    value -= efficientRoomUsing;
                    CountEfficiency++;
                }
            }

            int firstHour = int.MaxValue;
            foreach (var item in timetable)
                if (item.Time.BlockIndex < firstHour)
                    firstHour = item.Time.BlockIndex;

            for (int i = firstHour; i < WorkHours - 1; i++)
            {
                bool isValue = false;
                foreach (var item in timetable)
                {
                    if(item.Time.BlockIndex == i) {
                        isValue = true;
                        break;
                    }
                }
                if (!isValue)
                {
                    value -= betweenHours;
                    CountBetweenTime++;
                }
            }
            return value;
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
                    
                    for (int j = 0; j <= rnd.Next(3, 8); j++)
                    {
                        TimeBlock timeBlock;
                        Combination combination;
                        do
                        {
                            combination = allCombinations[rnd.Next(0, allCombinations.Count - 1)];
                            timeBlock = new TimeBlock((Weekday)i, combination.Time.BlockIndex);
                        } while (tempComb.Keys.Any(time => ((time.BlockIndex == timeBlock.BlockIndex) && (time.Day == timeBlock.Day))));
                        tempComb.Add(timeBlock, combination);
                        allCombinations.Remove(combination);
                    }
                }
                allCurr.Add(tempComb);
            }
            return allCurr;
        }

        /// <summary>
        /// Generiert auf Heuristischer Methode den nahezu besten Stundenplan auf zufallsbasierter Erstellung
        /// </summary>
        /// <param name="offPeakTime">Gewichtung Randzeiten</param>
        /// <param name="betweenHours">Gewichtung der Zwischenstunden</param>
        /// <param name="efficientRoomUsing">Gewichtung der Effizients der Räume</param>
        /// <returns>Gibt den nahezu besten Stundenplan aus in einem Dictionary für jede Schulklasse und Tag</returns>
        public List<Dictionary<TimeBlock, Combination>> GetBestPlan(int offPeakTime = 5, int betweenHours = 5, int efficientRoomUsing = 20)
        {
            List<Dictionary<TimeBlock, Combination>> curriculums = new();

            int bestScore = 0;
            for (int i = 0; i < 100; i++)
            {
                List<Dictionary<TimeBlock, Combination>> currList = GetRandomCurriculum();
                int avgVal = 0;
                foreach (var cur in currList)
                    avgVal += GetValuation(cur.Values.ToList(), offPeakTime, betweenHours, efficientRoomUsing);
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
                SchoolClasses[i].Timetable = new Dictionary<TimeBlock, Combination>();

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

