using System.Collections.Generic;

namespace Stundenplaner_Projekt
{
    internal class SchoolClass
    {
        private string _name;
        private List<Student> _students;
        private Dictionary<TimeBlock, Combination> _timetable;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
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
        public SchoolClass(string name)
        {
            _name = name;
        }
        public SchoolClass(string name, List<Students> students)
        {
            _name = name;
            _students = students;
        }
        public void AddStudent(Student student) => Students.Add(student);
        public void RemoveSTudent(Student student) => Students.Remove(student);
    }
}