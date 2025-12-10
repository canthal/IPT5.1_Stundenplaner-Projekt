using Stundenplaner_Projekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StundenplanerTest
{
    internal static class TestData
    {
        public static List<Room> CreateRooms()
        {
            return new List<Room>
            {
                new Room("R001", 30),
                new Room("R002", 28),
                new Room("R003", 32),
                new Room("R004", 20),
                new Room("R005", 25),
                new Room("R006", 18),
                new Room("R007", 24),
                new Room("R008", 22),
                new Room("R009", 30),
                new Room("R010", 26)
            };
        }

        public static List<SchoolClass> CreateClasses()
        {
            return new List<SchoolClass>
            {
                new SchoolClass("1A", new List<Student>
                {
                    new Student("Anna", "Müller"),
                    new Student("Lukas", "Keller")
                }),
                new SchoolClass("1B", new List<Student>
                {
                    new Student("Noah", "Schmid"),
                    new Student("Mia", "Fischer")
                })
            };
        }

        public static List<Subject> CreateSubjects()
        {
            return new List<Subject>
            {
                new Subject("Mathematik"),
                new Subject("Deutsch"),
                new Subject("Englisch"),
                new Subject("Französisch"),
                new Subject("Informatik"),
                new Subject("Biologie"),
                new Subject("Chemie"),
                new Subject("Physik"),
                new Subject("Geschichte"),
                new Subject("Geografie")
            };
        }

        public static List<Teacher> CreateTeachers(List<Subject> subjects)
        {
            return new List<Teacher>
            {
                new Teacher("Anna", "Müller",
                    new List<Subject> { subjects[0], subjects[1] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 0),
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 1),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 1)
                    }),

                new Teacher("Lukas", "Keller",
                    new List<Subject> { subjects[2] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Montag, 3),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 0),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 0)
                    }),

                new Teacher("Mia", "Fischer",
                    new List<Subject> { subjects[3], subjects[4] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Montag, 4),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 2),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 2)
                    }),

                new Teacher("Noah", "Schmid",
                    new List<Subject> { subjects[5] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 0),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 1),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 0),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 3)
                    }),

                new Teacher("Lea", "Zimmermann",
                    new List<Subject> { subjects[6] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 1)
                    }),

                new Teacher("Jonas", "Weber",
                    new List<Subject> { subjects[7], subjects[0] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 3),
                        new TimeBlock(TimeBlock.Weekday.Montag, 4),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 0),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 4),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 3)
                    }),

                new Teacher("Emma", "Huber",
                    new List<Subject> { subjects[8] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 2),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 0),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 4)
                    }),

                new Teacher("Ben", "Meier",
                    new List<Subject> { subjects[9], subjects[1] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 0),
                        new TimeBlock(TimeBlock.Weekday.Montag, 3),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 1),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 4),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 2)
                    }),

                new Teacher("Sophie", "Arnold",
                    new List<Subject> { subjects[2], subjects[3] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 0),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 1)
                    }),

                new Teacher("Leon", "Graf",
                    new List<Subject> { subjects[4] },
                    new List<TimeBlock>
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Montag, 4),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 2),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 3)
                    })
            };
        }
    }
}
