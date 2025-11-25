using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using static Stundenplaner_Projekt.TimeBlock;

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
                new Room("R101", 24),
                new Room("R102", 22),
                new Room("R103", 20),
                new Room("R104", 18),
                new Room("R105", 20),
                new Room("R106", 22),
                new Room("R107", 24),
                new Room("R108", 26),
                new Room("R109", 20),
                new Room("R110", 18),
                new Room("LAB1", 18),
                new Room("LAB2", 20),
                new Room("GYM", 30),
                new Room("MUS1", 15),
                new Room("ART1", 16),
                new Room("WIR1", 22),
                new Room("LAW1", 20),
                new Room("PHIL1", 18),
                new Room("TEC1", 20),
                new Room("LAN1", 18)
            };

            teachers = new()
            {
                new Teacher("Anna", "Meier", new() { subjects[0], subjects[5] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 0),
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 4),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 6)
                    }),

                new Teacher("Lukas", "Keller", new() { subjects[1], subjects[2] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 5),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 7)
                    }),

                new Teacher("Mila", "Aydin", new() { subjects[4], subjects[19] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Montag, 3),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 5),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 7)
                    }),

                new Teacher("Jonas", "Stein", new() { subjects[10] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 0),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 2),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 4),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 6)
                    }),

                new Teacher("Laura", "Brunner", new() { subjects[3], subjects[8] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 0),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 2),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 6)
                    }),

                new Teacher("Felix", "Schmid", new() { subjects[6], subjects[7] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Montag, 4),
                        new TimeBlock(TimeBlock.Weekday.Montag, 6),
                        new TimeBlock(TimeBlock.Weekday.Montag, 8)
                    }),

                new Teacher("Nora", "Graf", new() { subjects[9], subjects[12] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 5),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 7),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 8)
                    }),

                new Teacher("Daniel", "Ziegler", new() { subjects[0], subjects[13] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 5),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 7),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 8),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 2)
                    }),

                new Teacher("Sophie", "Lehmann", new() { subjects[14], subjects[15] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 1),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 5),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 7)
                    }),

                new Teacher("Timo", "Bauer", new() { subjects[16], subjects[4] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 3),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 6)
                    }),

                new Teacher("Clara", "Huber", new() { subjects[18], subjects[2] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 0),
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 5),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 8)
                    }),

                new Teacher("Simon", "Fischer", new() { subjects[5], subjects[6] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 1),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 4),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 6),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 8)
                    }),

                new Teacher("Eva", "Arnold", new() { subjects[7], subjects[8] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 3),
                        new TimeBlock(TimeBlock.Weekday.Dienstag, 5),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 7),
                        new TimeBlock(TimeBlock.Weekday.Donnerstag, 8)
                    }),

                new Teacher("David", "Kunz", new() { subjects[9], subjects[10] },
                    new()
                    {
                        new TimeBlock(TimeBlock.Weekday.Montag, 2),
                        new TimeBlock(TimeBlock.Weekday.Montag, 4),
                        new TimeBlock(TimeBlock.Weekday.Mittwoch, 5),
                        new TimeBlock(TimeBlock.Weekday.Freitag, 7)
                    })
            };

            schoolClasses = new()
            {
                new SchoolClass("1C"),
                new SchoolClass("2A"),
                new SchoolClass("6C"),
                new SchoolClass("Informatik-Profil"),
                new SchoolClass("Wirtschaft-Profil"),
                new SchoolClass("D24a")

            };

            students = new()
            {
                new Student("Jonas", "Bachmann", "jonas.bachmann@example.com"),
                new Student("Amelia", "Hartmann", "amelia.hartmann@example.com"),
                new Student("Elias", "Graf", "elias.graf@example.com"),
                new Student("Lina", "Sutter", "lina.sutter@example.com"),
                new Student("David", "Arnold", "david.arnold@example.com"),
                new Student("Nina", "Schwarz", "nina.schwarz@example.com"),
                new Student("Samuel", "Baumgartner", "samuel.baumgartner@example.com"),
                new Student("Julia", "Frey", "julia.frey@example.com"),
                new Student("Matteo", "Kuhn", "matteo.kuhn@example.com"),
                new Student("Selina", "Ammann", "selina.ammann@example.com"),
            };


            while (true)
            {
                byte mainInput;
                do
                {
                    Console.Clear();
                    Console.WriteLine("0: Raum infos/bearbeiten");
                    Console.WriteLine("1: Lehrer infos/bearbeiten");
                    Console.WriteLine("2: Fach infos/bearbeiten");
                    Console.WriteLine("3: Schulklasse infos/bearbeiten");
                    Console.WriteLine("4: Schüler infos/bearbeiten");
                    Console.WriteLine("5: Stundenplan infos/bearbeiten");
                    Console.WriteLine("-----------------------------");
                } while (!byte.TryParse(Console.ReadLine(), out mainInput));

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
                            byte maxStudent;
                            do
                            {
                                Console.Clear();
                                Console.Write("max. Schüler (zahl): ");
                            } while (!byte.TryParse(Console.ReadLine(), out maxStudent));
                            rooms.Add(new Room(roomId, maxStudent));
                            Console.WriteLine("Raum hinzugefügt!");
                            Console.ReadKey();
                        }
                        if (roomInput == 2)
                        {
                            Console.Clear();

                            Console.WriteLine("Gebe Raum ID an: ");
                            for (int i = 0; i < rooms.Count; i++)
                                Console.WriteLine($"{i + 1}: {rooms[i].RoomId}, Max. Schüler: {rooms[i].MaxStudent}");
                            Console.WriteLine("--------------------------");

                            string roomIndex;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Gebe die Raum ID an: ");
                                for (int i = 0; i < rooms.Count; i++)
                                    Console.WriteLine($"{i}: {rooms[i].RoomId}, Max. Schüler: {rooms[i].MaxStudent}");
                                Console.WriteLine("--------------------------");
                                roomIndex = Console.ReadLine().ToUpper();
                            } while (!rooms.Any(r => r.RoomId == roomIndex));

                            rooms.Remove(rooms.First(r => r.RoomId == roomIndex));
                            Console.WriteLine("Raum wurde gelöscht!");
                            Console.ReadKey();
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
                                Console.WriteLine($" {t.FirstName} {t.LastName}, Unterrichtende Fächer: {string.Join( ", ", t.TeachingSubjects.Select(t => t.Name))}");
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
                                string subject = "";
                                bool findSubject = true;
                                do
                                {
                                    if (!findSubject)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Das Fach {subject} konnte nicht gefunden werden! Drücken zum erneut versuchen.");
                                        Console.ReadKey();
                                    }

                                    Console.Clear();
                                    Console.WriteLine("Wähle die Fächer aus: ");
                                    subjects.ForEach(s => Console.WriteLine($"{s.Name}"));
                                    Console.WriteLine("----------------------------------");
                                    subject = Console.ReadLine().ToLower();
                                    findSubject = subjects.Any(s => s.Name.ToLower() == subject);
                                } while (!findSubject);
                                Subject firstSatisfySubject = subjects.First(s => s.Name.ToLower() == subject);
                                chosenSubjects.Add(firstSatisfySubject);
                                Console.WriteLine($"Fach {firstSatisfySubject.Name} wurde hinzugefügt!");
                                do
                                {
                                    Console.Write("Willst du weitere Fächer hinzufügen? (j/n)");
                                    choice = Console.ReadKey().KeyChar.ToString().ToLower();
                                } while (choice != "j" && choice != "n");
                            } while (choice == "j");

                            Console.Clear();
                            HashSet<TimeBlock> workHours = new();
                            string continueAdding;
                            for (int i = 0; i < 5; i++)
                            {
                                Console.Clear();
                                do {
                                    Console.Clear();
                                    for (int j = 0; j < Hours.Length; j++)
                                    {
                                        Console.WriteLine($"{j}: {Hours[j]}");
                                    }
                                    int hour;
                                    do
                                    {
                                        Console.WriteLine($"Gebe den Index an an welchem der Lehrer am {(Weekday)i + 1} arbeitet: ");
                                    } while (!int.TryParse(Console.ReadLine(), out hour) && hour <= Hours.Length);
                                    workHours.Add(new TimeBlock((Weekday)i, hour));
                                    do
                                    {
                                        Console.WriteLine("Willst du noch mehr Zeiten an dem Tag hinzufügen? (j/n): ");
                                        continueAdding = Console.ReadKey().KeyChar.ToString().ToLower();
                                    } while (continueAdding != "j" && continueAdding != "n");
                                } while (continueAdding == "j");
                            }
                            teachers.Add(new Teacher(firstName, lastName, chosenSubjects.ToList(), workHours.ToList()));
                            Console.WriteLine("Lehrer wurde hinzugefügt!");
                            Console.ReadKey();
                        }
                        if(teacherInput == 2)
                        {
                            Console.Clear();
                            int teacherIndex;
                            do
                            {
                                for (int i = 0; i < teachers.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {teachers[i].FirstName} {teachers[i].LastName} {teachers[i].Email}");
                                }
                            } while (!int.TryParse(Console.ReadLine(), out teacherIndex) && teachers.Count <= teacherIndex);
                            Console.WriteLine($"Lehrer {teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} wurde entfernt");
                            teachers.Remove(teachers[teacherIndex]);
                            Console.ReadKey();
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
                            if (subjects.Count == 0)
                            {
                                Console.WriteLine("Es gibt keine Fächer in der Liste!");
                                continue;
                            }

                            int subjectIndex;
                            do {
                                Console.Clear();
                                Console.WriteLine("Gebe den Fach Index an: ");
                                for (int i = 0; i < subjects.Count; i++)
                                    Console.WriteLine($"{i}: {subjects[i].Name}");
                                Console.WriteLine("-----------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out subjectIndex) && subjects.Count <= subjectIndex);
                            Console.WriteLine($"Fach {subjects[subjectIndex].Name} wurde gelöscht!");
                            subjects.Remove(subjects[subjectIndex]);
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
                            if (schoolClasses.Count == 0)
                            {
                                Console.WriteLine("Es gibt keine Schulklassen in der Liste!");
                                continue;
                            }

                            Console.Clear();
                            int schoolClassIndex;
                            do {
                                Console.WriteLine("Gebe den Schulklasse Index an: ");
                                for (int i = 0; i < schoolClasses.Count; i++)
                                    Console.WriteLine($"{i}: {schoolClasses[i].Name}");
                                Console.WriteLine("----------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out schoolClassIndex) && schoolClasses.Count <= schoolClassIndex);
                            Console.WriteLine($"Schulklasse {schoolClasses[schoolClassIndex].Name} wurde gelöscht!");
                            schoolClasses.Remove(schoolClasses[schoolClassIndex]);
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        int studentInput;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("0: Schüler anzeigen");
                            Console.WriteLine("1: Schüler hinzufügen");
                            Console.WriteLine("2: Schüler entfernen");
                        } while (!int.TryParse(Console.ReadLine(), out studentInput));
                        Console.Clear();
                        if (studentInput == 0)
                        {
                            students.ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Email}"));
                            Console.ReadKey();
                        }
                        if(studentInput == 1)
                        {
                            Console.Write("Gebe den Vornamen des Schülers ein: ");
                            string firstName = Console.ReadLine();
                            Console.Write("Gebe den Nachnamen des Schülers ein: ");
                            string lastName = Console.ReadLine();
                            Console.Write("Gebe den Email des Schülers ein: ");
                            string email = Console.ReadLine();
                            students.Add(new Student(firstName, lastName, email));
                            Console.WriteLine("Schüler wurde hinzugefügt");
                            Console.ReadKey();
                        }
                        if(studentInput == 2)
                        {
                            if (students.Count == 0)
                            {
                                Console.WriteLine("Es gibt keine Schüler in der Liste!");
                                continue;
                            }
                            int studentIndex;
                            do
                            {
                                Console.Clear();
                                for (int i = 0; i < students.Count; i++)
                                    Console.WriteLine($"{i}: {students[i].FirstName} {students[i].LastName} {students[i].Email}");
                                Console.WriteLine("Gebe den Index des Schülers ein: ");
                            } while (!int.TryParse(Console.ReadLine(), out studentIndex) && students.Count <= studentIndex);
                            Console.WriteLine($"Schüler {students[studentIndex].FirstName} {students[studentIndex].LastName} wurde entfernt!");
                            students.Remove(students[studentIndex]);
                        }
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
                                if (item.Timetable == null) continue;
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
                            int offPeakTime, betweenTime, efficientRoom;
                            do
                            {
                                Console.Clear();
                                Console.Write("Wie hoch sollen Randzeiten gewichtet werden? (0 - 20): ");
                            } while (!int.TryParse(Console.ReadLine(), out offPeakTime));
                            do
                            {
                                Console.Clear();
                                Console.Write("Wie hoch sollen Zwischenstunden gewichtet werden? (0 - 20): ");
                            } while (!int.TryParse(Console.ReadLine(), out betweenTime));
                            do
                            {
                                Console.Clear();
                                Console.Write("Wie hoch soll die effiziente Nutzung der Räume gewichtet werden? (0 - 40): ");
                            } while (!int.TryParse(Console.ReadLine(), out efficientRoom));
                            
                            Console.Clear();

                            List<Dictionary<TimeBlock, Combination>> newTimtable = new CurriculumAlgo(schoolClasses, subjects, teachers, rooms).GetBestPlan(offPeakTime, betweenTime, efficientRoom);
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
        }
    }
}