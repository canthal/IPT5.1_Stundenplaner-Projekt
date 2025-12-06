using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Speichert alle Daten in den Klassen die während der Laufzeit hinzugekommen sind und gibt diese frei, wenn das Programm gestartet wird  
    /// </summary>
    public static class Datenmanager
    {
        private static readonly string basePath = AppContext.BaseDirectory;

        /// <summary>
        /// Pfad für Klasse Room
        /// </summary>
        private static string pathRoom = Path.Combine(basePath, "room.json") ;
        /// <summary>
        /// Pfad für Klasse Schulklasse
        /// </summary>
        private static string pathSchoolClass = Path.Combine(basePath, "schoolClass.json");
        /// <summary>
        /// Pfad für Klasse Student
        /// </summary>
        private static string pathStudent = Path.Combine(basePath, "student.json");
        /// <summary>
        /// Pfad für Klasse Subject
        /// </summary>
        private static string pathSubject = Path.Combine(basePath, "subject.json");
        /// <summary>
        /// Pfad für Klasse Teacher
        /// </summary>
        private static string pathTeacher = Path.Combine(basePath, "teacher.json");

        /// <summary>
        /// Speichert alle Daten von Klassen namens Room 
        /// </summary>
        /// <param name="rooms">Liste an Room welche gepeichert werden sollen</param>
        public static void SaveData(List<Room> rooms)
        {
            string json = JsonSerializer.Serialize(rooms);
            File.WriteAllText(pathRoom, json);
        }
        /// <summary>
        /// Speichert alle Daten von Klassen namens SchoolClass 
        /// </summary>
        /// <param name="rooms">Liste an SchoolClass welche gepeichert werden sollen</param>
        public static void SaveData(List<SchoolClass> schoolClasses)
        {
            string json = JsonSerializer.Serialize(schoolClasses);
            File.WriteAllText(pathSchoolClass, json);
        }
        /// <summary>
        /// Speichert alle Daten von Klassen namens Student 
        /// </summary>
        /// <param name="rooms">Liste an Student welche gepeichert werden sollen</param>
        public static void SaveData(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathStudent, json);
        }
        /// <summary>
        /// Speichert alle Daten von Klassen namens Subject 
        /// </summary>
        /// <param name="rooms">Liste an Subject welche gepeichert werden sollen</param>
        public static void SaveData(List<Subject> subjects)
        {
            string json = JsonSerializer.Serialize(subjects);
            File.WriteAllText(pathSubject, json);
        }
        /// <summary>
        /// Speichert alle Daten von Klassen namens Teacher 
        /// </summary>
        /// <param name="rooms">Liste an Teacher welche gepeichert werden sollen</param>
        public static void SaveData(List<Teacher> teacher)
        {
            string json = JsonSerializer.Serialize(teacher);
            File.WriteAllText(pathTeacher, json);
        }

        /// <summary>
        /// Ladet Daten aus dem Dateipfad von der Klasse Room
        /// </summary>
        /// <returns>Gibt die gefundenen Daten als Liste zurück</returns>
        public static List<Room> LoadDataRoom()
        {
            if (!File.Exists(pathRoom)) return new List<Room>();

            string json = File.ReadAllText(pathRoom);
            return JsonSerializer.Deserialize<List<Room>>(json);
        }

        /// <summary>
        /// Ladet Daten aus dem Dateipfad von der Klasse SchoolClass
        /// </summary>
        /// <returns>Gibt die gefundenen Daten als Liste zurück</returns>
        public static List<SchoolClass> LoadDataSchoolClass()
        {
            if (!File.Exists(pathSchoolClass)) return new List<SchoolClass>();

            string json = File.ReadAllText(pathSchoolClass);
            return JsonSerializer.Deserialize<List<SchoolClass>>(json);
        }

        /// <summary>
        /// Ladet Daten aus dem Dateipfad von der Klasse Student
        /// </summary>
        /// <returns>Gibt die gefundenen Daten als Liste zurück</returns>
        public static List<Student> LoadDataStudent()
        {
            if (!File.Exists(pathStudent)) return new List<Student>();

            string json = File.ReadAllText(pathStudent);
            return JsonSerializer.Deserialize<List<Student>>(json);
        }

        /// <summary>
        /// Ladet Daten aus dem Dateipfad von der Klasse Subject
        /// </summary>
        /// <returns>Gibt die gefundenen Daten als Liste zurück</returns>
        public static List<Subject> LoadDataSubject()
        {
            if (!File.Exists(pathSubject)) return new List<Subject>();

            string json = File.ReadAllText(pathSubject);
            return JsonSerializer.Deserialize<List<Subject>>(json);
        }

        /// <summary>
        /// Ladet Daten aus dem Dateipfad von der Klasse Teacher
        /// </summary>
        /// <returns>Gibt die gefundenen Daten als Liste zurück</returns>
        public static List<Teacher> LoadDataTeacher()
        {
            if (!File.Exists(pathTeacher)) return new List<Teacher>();

            string json = File.ReadAllText(pathTeacher);
            return JsonSerializer.Deserialize<List<Teacher>>(json);
        }
    }
}
