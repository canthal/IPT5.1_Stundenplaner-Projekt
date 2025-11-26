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
            // Listen von Klassen die für die Laufzeit gebraucht werden, von Dateimanager aus.
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

            // Benutzerinterface welches so lange läuft bis Program geschlossen wird
            while (true)
            {
                // input der Aktivität
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

                // Bestimmung welche Aktivität, aufgrund des Inputs
                switch (mainInput)
                {
                    // Verwaltung Räume
                    case 0:
                        Console.Clear();
                        Console.WriteLine("0: Räume anzeigen");
                        Console.WriteLine("1: Raum hinzufügen");
                        Console.WriteLine("2: Raum entfernen");
                        byte roomInput = Convert.ToByte(Console.ReadLine());

                        // Räume anzeigen
                        if (roomInput == 0) {
                            Console.Clear();
                            rooms.ForEach(r => Console.WriteLine($"RaumID: {r.RoomId}, Max. Schüler: {r.MaxStudent}"));
                            Console.ReadLine();
                        }
                        // Räume hinzufügen
                        if (roomInput == 1)
                        {
                            Console.Clear();
                            string roomId;
                            do
                            {
                                Console.Clear();
                                Console.Write("RaumId: ");
                                roomId = Console.ReadLine();
                            } while (roomId.Length == 0);
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
                        // Räume entfernen
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

                    // Lehrer Verwaltung
                    case 1:
                        Console.Clear();
                        Console.WriteLine("0: Lehrer anzeigen");
                        Console.WriteLine("1: Lehrer hinzufügen");
                        Console.WriteLine("2: Lehrer entfernen");
                        Console.WriteLine("3: Fach zu Lehrer hinzufügen");
                        Console.WriteLine("4: Fach zu Lehrer entfernen");
                        byte teacherInput = Convert.ToByte(Console.ReadLine());

                        // Lehrer anzeigen
                        if(teacherInput == 0) 
                        {
                            Console.Clear();
                            Console.WriteLine("Alle Lehrer: ");
                            foreach (var t in teachers)
                                Console.WriteLine($" {t.FirstName, -10} {t.LastName, -15} Unterrichtende Fächer: {string.Join( ", ", t.TeachingSubjects.Select(t => t.Name))}");
                            Console.ReadLine();
                        }
                        // Lehrer hinzufügen
                        if (teacherInput == 1) {
                            Console.Clear();
                            string firstName;
                            do
                            {
                                Console.Clear();
                                Console.Write("Vorname: ");
                                firstName = Console.ReadLine();
                            } while (firstName.Length == 0);

                            string lastName;
                            do
                            {
                                Console.Clear();
                                Console.Write("Nachname: ");
                                lastName = Console.ReadLine();
                            } while (lastName.Length == 0);

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
                                    Console.Write("Willst du weitere Fächer hinzufügen? (j/n): ");
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
                            Console.WriteLine($"{firstName} {lastName} wurde hinzugefügt!");
                            Console.ReadKey();
                        }
                        // Lehrer entfernen
                        if(teacherInput == 2)
                        {
                            Console.Clear();
                            int teacherIndex;
                            do
                            {
                                Console.WriteLine("Gebe den Index an der links steht zur passenden Lehrperson: ");
                                for (int i = 0; i < teachers.Count; i++)
                                {
                                    Console.WriteLine($"{i}: {teachers[i].FirstName} {teachers[i].LastName} {teachers[i].Email}");
                                }
                            } while (!int.TryParse(Console.ReadLine(), out teacherIndex) && teachers.Count <= teacherIndex);
                            Console.WriteLine($"Lehrer {teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} wurde entfernt");
                            teachers.Remove(teachers[teacherIndex]);
                            Console.ReadKey();
                        }

                        if (teacherInput == 3)
                        {
                            int teacherIndex, chooseSubject;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Gebe den Index vom Lehrer an: ");
                                for (int i = 0; i < teachers.Count; i++)
                                    Console.WriteLine($"{i} {teachers[i].FirstName, -10} {teachers[i].LastName, -10} {teachers[i].Email, -30}");
                                Console.WriteLine("-------------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out teacherIndex));
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"{teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} - Wähle das entsprechnde Fach aus: ");
                                for (int i = 0; i < subjects.Count; i++)
                                    Console.WriteLine($"{i}: {subjects[i].Name}");
                                Console.WriteLine("-------------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out chooseSubject) && chooseSubject <= subjects.Count);
                            teachers[teacherIndex].AddSubject(subjects[chooseSubject]);
                            Console.WriteLine($"Das Fach {subjects[chooseSubject].Name} wurde bei {teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} hinzugefügt");
                            Console.ReadLine();
                        }
                        if (teacherInput == 4)
                        {
                            int teacherIndex, chooseSubject;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Gebe den Index vom Lehrer an: ");
                                for (int i = 0; i < teachers.Count; i++)
                                    Console.WriteLine($"{i} {teachers[i].FirstName,-10} {teachers[i].LastName,-10} {teachers[i].Email,-30}");
                                Console.WriteLine("-------------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out teacherIndex));
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"{teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} - Wähle das entsprechnde Fach aus: ");
                                for (int i = 0; i < teachers[teacherIndex].TeachingSubjects.Count; i++)
                                    Console.WriteLine($"{i}: {teachers[teacherIndex].TeachingSubjects[i].Name}");
                                Console.WriteLine("-------------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out chooseSubject) && chooseSubject <= subjects.Count);
                            Console.WriteLine($"Das Fach {teachers[teacherIndex].TeachingSubjects[chooseSubject].Name} wurde bei {teachers[teacherIndex].FirstName} {teachers[teacherIndex].LastName} entfernt");
                            teachers[teacherIndex].RemoveSubjects(teachers[teacherIndex].TeachingSubjects[chooseSubject].Name);
                            Console.ReadLine();
                        }
                        break;
                    // Verwaltung Fächer
                    case 2:
                        Console.Clear();
                        Console.WriteLine("0: Fächer anzeigen");
                        Console.WriteLine("1: Fächer hinzufügen");
                        Console.WriteLine("2: Fächer entfernen");
                        byte subjectInput = Convert.ToByte(Console.ReadLine());

                        // Fächer anzeigen
                        if (subjectInput == 0) {
                            Console.Clear();
                            subjects.ForEach(s => Console.WriteLine($"{s.Name}"));
                            Console.ReadLine();
                        }
                        // Fächer hinzufügen
                        if (subjectInput == 1)
                        {
                            string subjectName;
                            do
                            {
                                Console.Clear();
                                Console.Write("Fachname: ");
                                subjectName = Console.ReadLine();
                            } while (subjectName.Length == 0);
                            subjects.Add(new Subject(subjectName));
                            Console.WriteLine("Fach hinzugefügt!");
                            Console.ReadLine();
                        }
                        // Fächer entfernen
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
                    // Verwaltung Schulklassen
                    case 3:
                        Console.Clear();
                        Console.WriteLine("0: Schulklassen anzeigen");
                        Console.WriteLine("1: Schulklasse hinzufügen");
                        Console.WriteLine("2: Schulklasse entfernen");
                        Console.WriteLine("3: Schüler in Schulklasse einfügen");
                        Console.WriteLine("4: Schüler in Schulklasse entfernen");

                        byte schoolClassInput = Convert.ToByte(Console.ReadLine());

                        // Schulklassen anzeigen
                        if (schoolClassInput == 0) {
                            Console.Clear();
                            Console.WriteLine("Alle Schulklassen: ");
                            schoolClasses.ForEach(s => Console.WriteLine($"{s.Name}"));
                            Console.ReadLine();
                        }
                        // Schulklassen hinzufügen
                        if (schoolClassInput == 1)
                        {
                            string schoolClassName;
                            do
                            {
                                Console.Clear();
                                Console.Write("Name von der Schulklasse: ");
                                schoolClassName = Console.ReadLine();
                            } while (schoolClassName.Length == 0);
                            schoolClasses.Add(new SchoolClass(schoolClassName));
                            Console.WriteLine("Schulklasse hinzugefügt!");
                            Console.ReadLine();
                        }
                        // Schulklassen entfernen
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
                        if (schoolClassInput == 3)
                        {
                            int schoolClassIndex;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Wähle den Index aus von der Klasse die ausgewählt werden soll: ");
                                for (int i = 0; i < schoolClasses.Count; i++)
                                    Console.WriteLine($"{i}: {schoolClasses[i].Name}");
                                Console.WriteLine("-----------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out schoolClassIndex));

                            int chooseStudent;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"{schoolClasses[schoolClassIndex].Name} - Wähle den Index vom Schüler: ");
                                Console.WriteLine("-----------------------------------");
                                for (int i = 0; i < students.Count; i++)
                                    Console.WriteLine($"{i} {students[i].FirstName} {students[i].LastName}");
                                Console.WriteLine("-----------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out chooseStudent));

                            schoolClasses[schoolClassIndex].AddStudent(students[chooseStudent]);
                            Console.WriteLine($"Schüler {students[chooseStudent].FirstName} {students[chooseStudent].LastName} wurde hinzugefügt");
                            Console.ReadLine();
                        }
                        if (schoolClassInput == 4)
                        {
                            int schoolClassIndex;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Wähle den Index aus von der Klasse die ausgewählt werden soll: ");
                                for (int i = 0; i < schoolClasses.Count; i++)
                                    Console.WriteLine($"{i}: {schoolClasses[i].Name}");
                                Console.WriteLine("-----------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out schoolClassIndex));

                            int chooseStudent;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"{schoolClasses[schoolClassIndex].Name} - Wähle den Index vom Schüler: ");
                                Console.WriteLine("-----------------------------------");
                                for (int i = 0; i < students.Count; i++)
                                    Console.WriteLine($"{i} {students[i].FirstName} {students[i].LastName}");
                                Console.WriteLine("-----------------------------------");
                            } while (!int.TryParse(Console.ReadLine(), out chooseStudent));

                            schoolClasses[schoolClassIndex].RemoveStudent(students[chooseStudent]);
                            Console.WriteLine($"Schüler {students[chooseStudent].FirstName} {students[chooseStudent].LastName} wurde entfernt");
                            Console.ReadLine();
                        }
                        break;
                    // Verwaltung Studenten
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
                        // Studenten anzeigen
                        if (studentInput == 0)
                        {
                            Console.WriteLine("Alle Schüler: ");
                            students.ForEach(s => Console.WriteLine($"{s.FirstName, -15} {s.LastName, -15} {s.Email}"));
                            Console.ReadKey();
                        }
                        // Studenten hinzufügen
                        if(studentInput == 1)
                        {
                            string firstName, lastName, email;
                            do
                            {
                                Console.Clear();
                                Console.Write("Gebe den Vornamen des Schülers ein: ");
                                firstName = Console.ReadLine();
                            } while (firstName.Length == 0);
                            do
                            {
                                Console.Clear();
                                Console.Write("Gebe den Nachnamen des Schülers ein: ");
                                lastName = Console.ReadLine();
                            } while (lastName.Length == 0);
                            do
                            {
                                Console.Clear();
                                Console.Write("Gebe den Email des Schülers ein: ");
                                email = Console.ReadLine();
                            } while (email.Length == 0);

                            students.Add(new Student(firstName, lastName, email));
                            Console.WriteLine("Schüler wurde hinzugefügt");
                            Console.ReadKey();
                        }
                        // Studenten entfernen
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
                    // Verwaltung & Erstellung Stundenplan
                    case 5:
                        Console.Clear();
                        Console.WriteLine("0: bestehenden Stundeplan anzeigen");
                        Console.WriteLine("1: neuen Stundenplan erstellen");
                        byte timetableInput = Convert.ToByte(Console.ReadLine());
                        // Stundenplan anzeigen
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
                        // neuen Stundenplan erstellen
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

                            new CurriculumAlgo(schoolClasses, subjects, teachers, rooms).GetBestPlan(offPeakTime, betweenTime, efficientRoom);
                            foreach (var schoolClass in schoolClasses)
                            {
                                if (schoolClass.Timetable == null) continue;
                                Console.WriteLine(schoolClass.Name);
                                foreach (var timetable in schoolClass.Timetable)
                                    Console.WriteLine($"{timetable.Value.Time.Day, -12} {timetable.Value.Time.GetHours, -6} \t {timetable.Value.Subject.Name, -18} {timetable.Value.Teacher.FirstName, -10} {timetable.Value.Teacher.LastName, -12} {timetable.Value.Room.RoomId, -6}");
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