using System;
using System.Collections.Generic;

namespace Stundenplaner_Projekt
{
    internal class SchoolClass
    {
        /// <summary>
        /// Speicherort für Name der Schulklasse
        /// </summary>
        private string _name;
        /// <summary>
        /// Speicehort für die Schüler in der Klasse
        /// </summary>
        private List<Student> _students = new();
        /// <summary>
        /// Speiceherort für den Stundenplan der Klasse
        /// </summary>
        private Dictionary<TimeBlock, Combination> _timetable;
        
        /// <summary>
        /// Property von Name, überprüft ob Name nicht leer ist
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length == 0) throw new FormatException("Der Name darf nicht leer sein!");
                _name = value;
            }
        }
        /// <summary>
        /// Property von Stundenten
        /// </summary>
        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
            }
        }
        /// <summary>
        /// Property von Timetable
        /// </summary>
        public Dictionary<TimeBlock, Combination> Timetable
        {
            get
            {
                return _timetable;
            }
            set
            {
                _timetable = value;
            }
        }

        /// <summary>
        /// Setzt Schulklasse, nimmt ein Argument an Name
        /// </summary>
        /// <param name="name">Name der Klasse</param>
        public SchoolClass(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Setzt Schulklasse, nimmt zwei Argumente an name und students
        /// </summary>
        /// <param name="name">Name der Klasse</param>
        /// <param name="students">Schüler in der Klasse</param>
        public SchoolClass(string name, List<Student> students)
        {
            _name = name;
            _students = students;
        }
        
        /// <summary>
        /// Fügt Schüler zur Klasse hinzu
        /// </summary>
        /// <param name="student">Schüler welcher hinzugefügt werden soll</param>
        public void AddStudent(Student student) => Students.Add(student);
        /// <summary>
        /// Entfernt Schüler aus einer Klasse
        /// </summary>
        /// <param name="student">Schüler der Entfernt werden soll</param>
        public void RemoveStudent(Student student) => Students.Remove(student);
    }
}