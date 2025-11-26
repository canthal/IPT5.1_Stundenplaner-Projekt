using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text.Json.Serialization;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Klasse Lehrer welche Schulklassen unterrichten, erbt von Person
    /// </summary>
    internal class Teacher : Person
    {
        /// <summary>
        /// Speicher für Liste an Fächern die unterrichtet werden vom Lehrer
        /// </summary>
        private List<Subject> _teachingSubjects;
        /// <summary>
        /// Verfügbarkeit vom Lehrer werden hier gespeichert
        /// </summary>
        private List<TimeBlock> _availableBlocks;

        /// <summary>
        /// Property für Fächer, welches der Lehrer unterrichtet
        /// </summary>
        public List<Subject> TeachingSubjects { get => _teachingSubjects; set => _teachingSubjects = value; }

        /// <summary>
        /// Propery für verfügbare Zeiten vom Lehrer
        /// </summary>
        public List<TimeBlock> AvailableBlocks { get => _availableBlocks; set => _availableBlocks = value; }

 
        /// <summary>
        /// Setzt Lehrer, nimmt vier Parameter an.
        /// </summary>
        /// <param name="firstName">Vorname des Lehrers</param>
        /// <param name="lastName">Nachname des Lehrers</param>
        /// <param name="teachingSubjects">Unterrichtende Fächer</param>
        /// <param name="availableBlocks">Verfügbare Zeiten</param>
        [JsonConstructor]
        public Teacher(string firstName, string lastName, List<Subject> teachingSubjects, List<TimeBlock> availableBlocks)
        {
            FirstName = firstName;
            LastName = lastName;
            TeachingSubjects = teachingSubjects;
            AvailableBlocks = availableBlocks;
        }

        /// <summary>
        /// Fügt Fach zum Lehrer hinzu
        /// </summary>
        /// <param name="subject">Fach welches hinzugefügt werden soll</param>
        public void AddSubject(Subject subject)
        {
            TeachingSubjects.Add(subject);
        }

        /// <summary>
        /// Entfernt Fach vom Lehrer
        /// </summary>
        /// <param name="subject">Fach welches entfernt werden soll</param>
        public void RemoveSubjects(Subject subject)
        {
            TeachingSubjects.Remove(subject);
        }

        public void RemoveSubjects(string subjectName) => TeachingSubjects.Remove(TeachingSubjects.First(s => s.Name == subjectName));
    }
}
