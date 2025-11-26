using System;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Abstrakte Klasse Person wird als Oberklasse verwendet für Teacher und Student
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Speicherort für den Vorname der Person
        /// </summary>
        private string _firstName;
        /// <summary>
        /// Speicherort für den Nachname der Person
        /// </summary>
        private string _lastName;
        /// <summary>
        /// Speicherort für die Email Adresse der Person
        /// </summary>
        private string _email;

        /// <summary>
        /// Property für den Vornamen, prüft ob string nicht leer ist
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set 
            {
                if (value.Length == 0) throw new FormatException("Die Länge des Namens darf nicht 0 sein!");
                _firstName = value;
            }
        }

        /// <summary>
        /// Property für den Nachnamen, prüft ob string nicht leer ist
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0) throw new FormatException("Die Länge des Namens darf nicht 0 sein!");
                _lastName = value;
            }
        }

        /// <summary>
        /// Property für die Email, kontrolliert beinhaltung von Zeichen und @ Zeichen
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                // if (value.Length == 0 && value.Contains("@")) throw new FormatException("Die Länge der E-Mail darf nicht 0 sein und muss ein @ beinhalten!");
                _email = value;
            }
        }
    }
}
