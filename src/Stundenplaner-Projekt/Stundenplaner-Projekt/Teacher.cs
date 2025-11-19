using System;
using System.Collections.Generic;

namespace Stundenplaner_Projekt
{
    internal class Teacher : Person
    {
        private List<Subject> _teachingSubjects;
        private List<TimeBlock> _availableBlocks;

        public List<Subject> TeachingSubjects { get => _teachingSubjects; set => _teachingSubjects = value; }

        public List<TimeBlock> AvailableBlocks { get => _availableBlocks; set => _availableBlocks = value; }

        public Teacher(string firstName, string lastName, List<Subject> teachingSubjects, List<TimeBlock> availableBlocks)
        {
            FirstName = firstName;
            LastName = lastName;
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
