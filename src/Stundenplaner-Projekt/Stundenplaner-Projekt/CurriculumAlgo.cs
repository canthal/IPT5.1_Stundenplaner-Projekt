using System;
using static Stundenplaner_Projekt.TimeBlock;

namespace Stundenplaner_Projekt
{
    internal class CurriculumAlgo
    {
        private List<Subject> _subjects;
        private List<Teacher> _teachers;
        private List<SchoolClass> _schoolClasses;
        private List<Room> _rooms;

        internal List<Subject> Subjects
        {
            get => _subjects;
            set => _subjects = value;
        }

        internal List<Teacher> Teachers
        {
            get => _teachers;
            set => _teachers = value;
        }

        internal List<Room> Rooms
        {
            get => _rooms;
            set => _rooms = value;
        }

        internal List<SchoolClass> SchoolClasses
        {
            get => _schoolClasses;
            set => _schoolClasses = value;
        }

        internal CurriculumAlgo(List<SchoolClass> schoolClasses,List<Subject> subjects, List<Teacher> teachers, List<Room> rooms)
        {
            SchoolClasses = schoolClasses;
            Subjects = subjects;
            Teachers = teachers;
            Rooms = rooms;
        }

        private List<TimeBlock> GetCurricullumTime()
        {
            List<TimeBlock> timetable = new();
            for (int i = 1; i <= 5; i++)
                for (int j = 0; j < WorkHours; j++)
                    timetable.Add(new TimeBlock((Weekday)i, j));
            return timetable;
        }

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

        //private List<Combination> GetSortedList(List<Combination> unsortedCombinations)
        //{
        //    int temp;
        //    Combination tempComb;
        //    bool swapped;

        //    List<List<Combination>> allDaysCombinationList = new();
        //    allDaysCombinationList.Add(SplitList(unsortedCombinations, Weekday.Monday));
        //    allDaysCombinationList.Add(SplitList(unsortedCombinations, Weekday.Tuesday));
        //    allDaysCombinationList.Add(SplitList(unsortedCombinations, Weekday.Wednesday));
        //    allDaysCombinationList.Add(SplitList(unsortedCombinations, Weekday.Thursday));
        //    allDaysCombinationList.Add(SplitList(unsortedCombinations, Weekday.Friday));

        //    foreach (var dayCombination in allDaysCombinationList)
        //    {
        //        for (int i = 0; i < dayCombination.Count - 1; i++)
        //        {
        //            swapped = false;
        //            for (int j = 0; j < dayCombination.Count - 1; j++)
        //            {
        //                if (dayCombination[i].time.BlockIndex > dayCombination[j + 1].time.BlockIndex)
        //                {
        //                    temp = dayCombination[j].time.BlockIndex;
        //                    tempComb = dayCombination[j];
        //                    dayCombination[j] = dayCombination[j + 1];
        //                    dayCombination[j + 1] = tempComb;
        //                    swapped = true;
        //                }
        //            }

        //            if (!swapped)
        //                break;
        //        }
        //    }

        //    List<Combination> sortedList = new();
        //    allDaysCombinationList.ForEach(combination => sortedList.AddRange(combination));
        //    return sortedList;
        //}

        //private List<Combination> SplitList(List<Combination> combinations, Weekday weekday)
        //{
        //    List<Combination> dayCombinationList = new();
        //    dayCombinationList.AddRange(combinations.Where(combination => combination.time.Day == weekday));

        //    return dayCombinationList;
        //}

        private int GetValuation(List<Combination> timetable)
        {
            int value = 1000;
            HashSet<string> memorizeRooms = new(); 
            foreach (var t in timetable)
            {
                if ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == WorkHours - 1))
                {
                    value -= 5;
                }
                if (!memorizeRooms.Contains(t.Room.RoomId))
                    memorizeRooms.Add(t.Room.RoomId);
                else
                    value -= 5;
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
                if (!isValue) value -= 20;
            }
            return value;
        }

        private List<Dictionary<TimeBlock, Combination>> GetRandomCurriculum()
        {
            List<Dictionary<TimeBlock, Combination>> allCurr = new();
            Random rnd = new();
            List<Combination> allCombinations = GetCombinationMatrix();
            foreach (var schoolClass in SchoolClasses)
            {
                Dictionary<TimeBlock, Combination> tempComb = new();
                //schoolClass.Timetable.Clear();
                for (int i = 1; i <= 5; i++)
                {
                    for (int j = 0; j <= 4; j++)
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
                        //Console.WriteLine($"{schoolClass.Name} {timeBlock.Day} {combination.time.GetHours} {combination.room.RoomId} {combination.teacher.FirstName} {combination.teacher.LastName}");
                    }
                }
                allCurr.Add(tempComb);
            }
            return allCurr;
        }

        public List<Dictionary<TimeBlock, Combination>> GetBestPlan()
        {
            List<Dictionary<TimeBlock, Combination>> curriculums = new();

            int bestScore = 0;
            for (int i = 0; i < 100; i++)
            {
                List<Dictionary<TimeBlock, Combination>> currList = GetRandomCurriculum();
                int avgVal = 0;
                foreach (var cur in currList)
                    avgVal += GetValuation(cur.Values.ToList());
                avgVal /= currList.Count;

                if (avgVal > bestScore)
                {
                    curriculums = currList;
                    bestScore = avgVal;
                }
            }

            List<Dictionary<TimeBlock, Combination>> tempDic = new();
            for (int i = 0; i < curriculums.Count - 1; i++)
            {
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

