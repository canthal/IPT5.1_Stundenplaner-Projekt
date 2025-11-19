using System;
using System.Collections.Generic;

namespace Stundenplaner_Projekt
{
    public class Teacher
    {
        private string _firstName;
        private string _lastName;
        private List<Subject> _teachingSubjects;
        private List<TimeBlock> _availableBlocks;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public List<Subject> TeachingSubjects { get => _teachingSubjects; set => _teachingSubjects = value; }
        public List<TimeBlock> AvailableBlocks { get => _availableBlocks; set => _availableBlocks = value; }

        public Teacher(string firstName, string lastName, List<Subject> teachingSubjects, List<TimeBlock> availableBlocks)
        {
            _firstName = firstName;
            _lastName = lastName;
            _teachingSubjects = teachingSubjects;
            _availableBlocks = availableBlocks;
        }

        public void AddSubject(Subject subject)
        {
            _teachingSubjects.Add(subject);
        }

        public void RemoveSubjects(Subject subject)
        {
            _teachingSubjects.Remove(subject);
        }
    }
}
