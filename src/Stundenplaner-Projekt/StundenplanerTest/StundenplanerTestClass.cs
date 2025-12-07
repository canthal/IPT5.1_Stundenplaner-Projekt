using Stundenplaner_Projekt;
using System.Xml;
using static Stundenplaner_Projekt.Datenmanager;
using static StundenplanerTest.TestData;

namespace StundenplanerTest
{
    [TestClass]
    public sealed class StundenplanerTestClass
    {
        [TestMethod]
        public void TeacherCollisionDetection()
        {
            // Arrange
            List<Room> rooms = CreateRooms();
            List<SchoolClass> schoolClasses = CreateClasses();
            List<Subject> subjects = CreateSubjects();
            List<Teacher> teachers = CreateTeachers(subjects);

            TimeBlock timeBlock = new TimeBlock(TimeBlock.Weekday.Montag, 1);
            teachers.Add(new Teacher("Max", "Mustermann", new List<Subject> { new Subject("Deutsch")}, new List<TimeBlock> { timeBlock }));

            // Act
            List<Dictionary<TimeBlock, Combination>> timetables = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms, new BasicValuation()).GetBestPlan();

            bool isDoubleTeacher = false;
            int count = 0;
            foreach (var time in timetables)
            {
                foreach (var t in time.Values)
                {
                    if(t.Teacher.FirstName == "Max" && t.Teacher.LastName == "Mustermann")
                        count++;
                    if (count > 1)
                        isDoubleTeacher = true;
                }
            }

            // Assert
            Assert.AreEqual(false, isDoubleTeacher);
        }

        [TestMethod]
        public void RoomCollisionDetection()
        {
            // Arrange
            List<Room> rooms = CreateRooms();
            List<SchoolClass> schoolClasses = CreateClasses();
            List<Subject> subjects = CreateSubjects();
            List<Teacher> teachers = CreateTeachers(subjects);

            rooms.Add(new Room("new Room", 20));

            // Act
            List<Dictionary<TimeBlock, Combination>> timetables = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms, new BasicValuation()).GetBestPlan();
            
            List<int> times = new();
            foreach (var time in timetables)
            {
                foreach (var t in time.Values)
                {
                    if (t.Room.RoomId == "new Room" && times.Contains(t.Time.BlockIndex))
                        times.Add(t.Time.BlockIndex);
                }
            }

            // Assert
            Assert.AreEqual(false, times.Count > 1);
        }

        [TestMethod]
        public void ReduceOffPeakValuation()
        {
            // Arrange
            List<Room> rooms = CreateRooms();
            List<SchoolClass> schoolClasses = CreateClasses();
            List<Subject> subjects = CreateSubjects();
            List<Teacher> teachers = CreateTeachers(subjects);

            // Act
            List<Dictionary<TimeBlock, Combination>> timetablesLowOffPeak = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms, new BasicValuation(5, 5, 5)).GetBestPlan();

            List<Dictionary<TimeBlock, Combination>> timetablesHighOffPeak = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms, new BasicValuation(20, 5, 5)).GetBestPlan();

            int countLowOffPeak = 0;
            foreach (var time in timetablesLowOffPeak)
                foreach (var t in time.Values)
                    if ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == TimeBlock.WorkHours - 1))
                        countLowOffPeak++;

            int countHighOffPeak = 0;
            foreach (var time in timetablesLowOffPeak)
                foreach (var t in time.Values)
                    if ((t.Time.BlockIndex == 0) || (t.Time.BlockIndex == TimeBlock.WorkHours - 1))
                        countHighOffPeak++;

            // Assert
            Assert.AreEqual(true, countHighOffPeak <= countLowOffPeak);
        }

        [TestMethod]
        public void ErrorIfToFewDataByTimtableGen()
        {
            // Arrange
            List<SchoolClass> schoolClasses = CreateClasses();
            List<Subject> subjects = CreateSubjects();
            List<Teacher> teachers = CreateTeachers(subjects);
            List<Room> rooms = new();

            // Act & Assert
            Assert.ThrowsException<Exception>(() =>
            {
                new CurriculumAlgo(schoolClasses, subjects, teachers, rooms, new BasicValuation()).GetBestPlan();
            });
        }

        [TestMethod]
        public void CheckTeacherSubjectAdd()
        {
            Subject german = new Subject("Deutsch");
            List<Subject> subjects = new List<Subject> { german };
            Teacher teacher = new Teacher("Simon", "Koch", new List<Subject>(), new List<TimeBlock>());

            teacher.AddSubject(german);

            Assert.AreEqual(1, teacher.TeachingSubjects.Count);
            Assert.AreEqual(german.Name, teacher.TeachingSubjects.First().Name);
        }

        [TestMethod]
        public void CheckTeacherSubjectRemove()
        {
            Subject math = new Subject("Mathematik");
            Subject info = new Subject("Informatik");
            List<Subject> subjects = new List<Subject> { math, info };
            Teacher teacher = new Teacher("Simon", "Koch", subjects, new List<TimeBlock>());

            teacher.RemoveSubjects("Mathematik");

            Assert.AreEqual(1, teacher.TeachingSubjects.Count);
            Assert.AreEqual(info, teacher.TeachingSubjects.First());
        }
    }
}
