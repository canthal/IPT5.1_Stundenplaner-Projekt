using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Stundenplaner_Projekt
{
    internal static class Datenmanager
    {
        private const string pathRoom = "room.json";
        private const string pathSchoolClass = "schoolClass.json";
        private const string pathStudent = "student.json";
        private const string pathSubject = "subject.json";
        private const string pathTeacher = "teacher.json";

        internal static void SaveData(List<Room> rooms)
        {
            string json = JsonSerializer.Serialize(rooms);
            File.WriteAllText(pathRoom, json);
        }
        internal static void SaveData(List<SchoolClass> schoolClasses)
        {
            string json = JsonSerializer.Serialize(schoolClasses);
            File.WriteAllText(pathSchoolClass, json);
        }

        internal static void SaveData(List<Students> students)
        {
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathStudent, json);
        }

        internal static void SaveData(List<Subject> subjects)
        {
            string json = JsonSerializer.Serialize(subjects);
            File.WriteAllText(pathSubject, json);
        }

        internal static void SaveData(List<Teacher> teacher)
        {
            string json = JsonSerializer.Serialize(teacher);
            File.WriteAllText(pathTeacher, json);
        }

        internal static List<Room> LoadDataRoom()
        {
            if (!File.Exists(pathRoom)) return new List<Room>();

            string json = File.ReadAllText(pathRoom);
            return JsonSerializer.Deserialize<List<Room>>(json);
        }

        internal static List<SchoolClass> LoadDataSchoolClass()
        {
            if (!File.Exists(pathSchoolClass)) return new List<SchoolClass>();

            string json = File.ReadAllText(pathSchoolClass);
            return JsonSerializer.Deserialize<List<SchoolClass>>(json);
        }

        internal static List<Students> LoadDataStudent()
        {
            if (!File.Exists(pathStudent)) return new List<Students>();

            string json = File.ReadAllText(pathStudent);
            return JsonSerializer.Deserialize<List<Students>>(json);
        }

        internal static List<Subject> LoadDataSubject()
        {
            if (!File.Exists(pathSubject)) return new List<Subject>();

            string json = File.ReadAllText(pathSubject);
            return JsonSerializer.Deserialize<List<Subject>>(json);
        }

        internal static List<Teacher> LoadDataTeacher()
        {
            if (!File.Exists(pathTeacher)) return new List<Teacher>();

            string json = File.ReadAllText(pathTeacher);
            return JsonSerializer.Deserialize<List<Teacher>>(json);
        }
    }
}
