using System;
using System.Linq;
using System.Collections.Generic;

namespace Stundenplaner_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = Datenmanager.LoadDataRoom();
            List<SchoolClass> schoolClasses = Datenmanager.LoadDataSchoolClass();
            List<Student> students = Datenmanager.LoadDataStudent();
            List<Subject> subjects = Datenmanager.LoadDataSubject();
            List<Teacher> teachers = Datenmanager.LoadDataTeacher();

            subjects = new()
            {
                new Subject("Mathematik"),
                new Subject("Deutsch"),
                new Subject("Englisch"),
                new Subject("Französisch"),
                new Subject("Informatik"),
                new Subject("Physik"),
                new Subject("Chemie"),
                new Subject("Biologie"),
                new Subject("Geschichte"),
                new Subject("Geografie"),
                new Subject("Sport"),
                new Subject("Musik"),
                new Subject("Kunst"),
                new Subject("Wirtschaft"),
                new Subject("Recht"),
                new Subject("Philosophie"),
                new Subject("Technik"),
                new Subject("Italienisch"),
                new Subject("Spanisch"),
                new Subject("Programmierung")
            };

            rooms = new()
            {
                new Room("R101", subjects[0], 24),
                new Room("R102", subjects[1], 22),
                new Room("R103", subjects[2], 20),
                new Room("R104", subjects[3], 18),
                new Room("R105", subjects[4], 20),
                new Room("R106", subjects[5], 22),
                new Room("R107", subjects[6], 24),
                new Room("R108", subjects[7], 26),
                new Room("R109", subjects[8], 20),
                new Room("R110", subjects[9], 18),
                new Room("LAB1", subjects[4], 18),
                new Room("LAB2", subjects[19], 20),
                new Room("GYM",  subjects[10], 30),
                new Room("MUS1", subjects[11], 15),
                new Room("ART1", subjects[12], 16),
                new Room("WIR1", subjects[13], 22),
                new Room("LAW1", subjects[14], 20),
                new Room("PHIL1", subjects[15], 18),
                new Room("TEC1", subjects[16], 20),
                new Room("LAN1", subjects[17], 18)
            };

            teachers = new()
            {
                new Teacher("Anna", "Meier", new() { subjects[0], subjects[5] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 0),
                        new TimeBlock(TimeBlock.Weekday.Monday, 2),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 4),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 6)
                    }),

                new Teacher("Lukas", "Keller", new() { subjects[1], subjects[2] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 1),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 3),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 5),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 7)
                    }),

                new Teacher("Mila", "Aydin", new() { subjects[4], subjects[19] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 1),
                        new TimeBlock(TimeBlock.Weekday.Monday, 3),
                        new TimeBlock(TimeBlock.Weekday.Friday, 5),
                        new TimeBlock(TimeBlock.Weekday.Friday, 7)
                    }),

                new Teacher("Jonas", "Stein", new() { subjects[10] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 0),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 2),
                        new TimeBlock(TimeBlock.Weekday.Friday, 4),
                        new TimeBlock(TimeBlock.Weekday.Friday, 6)
                    }),

                new Teacher("Laura", "Brunner", new() { subjects[3], subjects[8] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 0),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 2),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 4),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 6)
                    }),

                new Teacher("Felix", "Schmid", new() { subjects[6], subjects[7] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 2),
                        new TimeBlock(TimeBlock.Weekday.Monday, 4),
                        new TimeBlock(TimeBlock.Weekday.Monday, 6),
                        new TimeBlock(TimeBlock.Weekday.Monday, 8)
                    }),

                new Teacher("Nora", "Graf", new() { subjects[9], subjects[12] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 3),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 5),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 7),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 8)
                    }),

                new Teacher("Daniel", "Ziegler", new() { subjects[0], subjects[13] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 5),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 7),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 8),
                        new TimeBlock(TimeBlock.Weekday.Friday, 2)
                    }),

                new Teacher("Sophie", "Lehmann", new() { subjects[14], subjects[15] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 1),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 3),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 5),
                        new TimeBlock(TimeBlock.Weekday.Friday, 7)
                    }),

                new Teacher("Timo", "Bauer", new() { subjects[16], subjects[4] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 1),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 3),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 4),
                        new TimeBlock(TimeBlock.Weekday.Friday, 6)
                    }),

                new Teacher("Clara", "Huber", new() { subjects[18], subjects[2] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 0),
                        new TimeBlock(TimeBlock.Weekday.Monday, 2),
                        new TimeBlock(TimeBlock.Weekday.Friday, 5),
                        new TimeBlock(TimeBlock.Weekday.Friday, 8)
                    }),

                new Teacher("Simon", "Fischer", new() { subjects[5], subjects[6] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 1),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 4),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 6),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 8)
                    }),

                new Teacher("Eva", "Arnold", new() { subjects[7], subjects[8] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 3),
                        new TimeBlock(TimeBlock.Weekday.Tuesday, 5),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 7),
                        new TimeBlock(TimeBlock.Weekday.Thursday, 8)
                    }),

                new Teacher("David", "Kunz", new() { subjects[9], subjects[10] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Monday, 2),
                        new TimeBlock(TimeBlock.Weekday.Monday, 4),
                        new TimeBlock(TimeBlock.Weekday.Wednesday, 5),
                        new TimeBlock(TimeBlock.Weekday.Friday, 7)
                    })
            };

            schoolClasses = new()
            {
                new SchoolClass("1C"),
                new SchoolClass("2A"),
                new SchoolClass("6C"),
                new SchoolClass("Informatik-Profil"),
                new SchoolClass("Wirtschaft-Profil")
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("0: Raum infos/bearbeiten");
                Console.WriteLine("1: Lehrer infos/bearbeiten");
                Console.WriteLine("2: Fach infos/bearbeiten");
                Console.WriteLine("3: Schulklasse infos/bearbeiten");
                Console.WriteLine("4: Schüler infos/bearbeiten");
                Console.WriteLine("5: Stundenplan infos/bearbeiten");
                Console.WriteLine("-----------------------------");
                byte mainInput = Convert.ToByte(Console.ReadLine());

                switch (mainInput)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("0: Räume anzeigen");
                        Console.WriteLine("1: Raum hinzufügen");
                        Console.WriteLine("2: Raum entfernen");
                        byte roomInput = Convert.ToByte(Console.ReadLine());

                        if (roomInput == 0) {
                            Console.Clear();
                            rooms.ForEach(r => Console.WriteLine($"RaumID: {r.RoomId}, Max. Schüler: {r.MaxStudent}"));
                            Console.ReadLine();
                        }
                        if (roomInput == 1)
                        {
                            Console.Clear();

                            Console.Write("RaumId: ");
                            string roomId = Console.ReadLine();
                            Console.Write("max. Schüler (zahl): ");
                            int maxStudent = Convert.ToInt32(Console.ReadLine());
                            rooms.Add(new Room(roomId, maxStudent));
                            Console.WriteLine("Raum hinzugefügt!");
                        }
                        if (roomInput == 2)
                        {
                            Console.Clear();

                            Console.WriteLine("Gebe Raum Index an: ");
                            for (int i = 0; i < rooms.Count; i++)
                                Console.WriteLine($"{i}: {rooms[i].RoomId}, Max. Schüler: {rooms[i].MaxStudent}");
                            Console.WriteLine("--------------------------");
                            int roomIndex = Convert.ToInt32(Console.ReadLine());
                            rooms.Remove(rooms[roomIndex]);
                            Console.WriteLine("Raum wurde gelöscht!");
                        }
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("0: Lehrer anzeigen");
                        Console.WriteLine("1: Lehrer hinzufügen");
                        Console.WriteLine("2: Lehrer entfernen");
                        byte teacherInput = Convert.ToByte(Console.ReadLine());

                        if(teacherInput == 0) 
                        {
                            Console.Clear();
                            foreach (var t in teachers)
                                Console.WriteLine($"{t.FirstName} {t.LastName}, Unterrichtende Fächer: {string.Join( ", ", t.TeachingSubjects.Select(t => t.Name))}");
                            Console.ReadLine();
                        }
                        if (teacherInput == 1) {
                            Console.Clear();
                            Console.Write("Vorname: ");
                            string firstName = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Nachname: ");
                            string lastName = Console.ReadLine();
                            HashSet<Subject> chosenSubjects = new();
                            string choice;
                            do
                            {
                                Console.Clear();
                                Console.Write("Wähle die Fächer aus: ");
                                subjects.ForEach(s => Console.WriteLine($"{s.Name}"));
                                string subject = Console.ReadLine();
                                Subject firstSatisfySubject = subjects.First(s => s.Name == subject);
                                chosenSubjects.Add(firstSatisfySubject);
                                Console.WriteLine($"Fach {firstSatisfySubject} wurde hinzugefügt!");
                                Console.Write("Willst du weitere Fächer hinzufügen? (j/n)");
                                choice = Console.ReadLine().ToLower();
                            } while (choice == "j");
                            // TimeBlock hinzufügen
                                //teachers.Add(new Teacher(firstName, lastName, chosenSubjects.ToList(), ));
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("0: Fächer anzeigen");
                        Console.WriteLine("1: Fächer hinzufügen");
                        Console.WriteLine("2: Fächer entfernen");
                        byte subjectInput = Convert.ToByte(Console.ReadLine());

                        if (subjectInput == 0) {
                            Console.Clear();
                            subjects.ForEach(s => Console.WriteLine($"{s.Name}"));
                            Console.ReadLine();
                        }
                        if (subjectInput == 1)
                        {
                            Console.Clear();
                            Console.Write("Fachname: ");
                            string subjectName = Console.ReadLine();
                            subjects.Add(new Subject(subjectName));
                            Console.WriteLine("Fach hinzugefügt!");
                            Console.ReadLine();
                        }
                        if (subjectInput == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("Gebe den Fach Index an: ");
                            for (int i = 0; i < subjects.Count; i++)
                                Console.WriteLine($"{i}: {subjects[i].Name}");
                            Console.WriteLine("-----------------------------");
                            int subjectIndex = Convert.ToInt32(Console.ReadLine());
                            subjects.Remove(subjects[subjectIndex]);
                            Console.WriteLine("Fach wurde gelöscht!");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("0: Schulklassen anzeigen");
                        Console.WriteLine("1: Schulklasse hinzufügen");
                        Console.WriteLine("2: Schulklasse entfernen");
                        byte schoolClassInput = Convert.ToByte(Console.ReadLine());

                        if (schoolClassInput == 0) {
                            Console.Clear();
                            schoolClasses.ForEach(s => Console.WriteLine($"{s.Name}"));
                            Console.ReadLine();
                        }
                        if (schoolClassInput == 1)
                        {
                            Console.Clear();

                            Console.Write("Name von der Schulklasse: ");
                            string schoolClassName = Console.ReadLine();
                            schoolClasses.Add(new SchoolClass(schoolClassName));
                            Console.WriteLine("Schulklasse hinzugefügt!");
                            Console.ReadLine();
                        }
                        if (schoolClassInput == 2)
                        {
                            Console.Clear();

                            Console.WriteLine("Gebe den Schulklasse Index an: ");
                            for (int i = 0; i < schoolClasses.Count; i++)
                                Console.WriteLine($"{i}: {schoolClasses[i].Name}");
                            Console.WriteLine("----------------------------------");
                            int schoolClassIndex = Convert.ToInt32(Console.ReadLine());
                            schoolClasses.Remove(schoolClasses[schoolClassIndex]);
                            Console.WriteLine("Schulklasse wurde gelöscht!");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        // Schüler einbauen
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("0: bestehenden Stundeplan anzeigen");
                        Console.WriteLine("1: neuen Stundenplan erstellen");
                        byte timetableInput = Convert.ToByte(Console.ReadLine());
                        if(timetableInput == 0)
                        {
                            Console.Clear();
                            foreach (var item in schoolClasses)
                            {
                                foreach (var t in item.Timetable)
                                {
                                    Console.WriteLine($"{t.Value.Time.Day} {t.Value.Time.GetHours} {t.Value.Subject.Name} - {t.Value.Teacher.FirstName} {t.Value.Teacher.LastName} - {t.Value.Room.RoomId}");
                                }
                                Console.WriteLine("------------------");
                            }
                            Console.ReadLine();
                        }
                        if (timetableInput == 1)
                        {
                            Console.Clear();
                            List<Dictionary<TimeBlock, Combination>> newTimtable = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms).GetBestPlan();
                            foreach (var schoolClass in newTimtable)
                            {
                                foreach (var timetable in schoolClass)
                                    Console.WriteLine($"{timetable.Value.Time.Day} {timetable.Value.Time.GetHours} {timetable.Value.Subject.Name} - {timetable.Value.Teacher.FirstName} {timetable.Value.Teacher.LastName} - {timetable.Value.Room.RoomId}");
                                Console.WriteLine("------------------");
                            }
                            Console.ReadLine();
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Falsche Eingabe!");
                        Console.ReadLine();
                        continue;
                }
            }

            //List<TimeBlock> timeBlockList = new();
            //for (int i = 1; i <= 5; i++)
            //{
            //    for (int j = 0; j < TimeBlock.WorkHours; j++)
            //    {
            //        var day = (TimeBlock.Weekday)i;
            //        timeBlockList.Add(new TimeBlock(day, j));
            //    }
            //}

            //List<Dictionary<TimeBlock, Combination>> combinationsList = new CurriculumAlgo(schoolClasses ,subjects, teachers, rooms).GetBestPlan();
            //foreach (var item in combinationsList)
            //{
            //    foreach (var t in item)
            //    {
            //        Console.WriteLine($"{t.Value.Time.Day} {t.Value.Time.GetHours} {t.Value.Subject.Name} - {t.Value.Teacher.FirstName} {t.Value.Teacher.LastName} - {t.Value.Room.RoomId}");
            //    }
            //    Console.WriteLine("------------------");
            //}
        }
    }
}