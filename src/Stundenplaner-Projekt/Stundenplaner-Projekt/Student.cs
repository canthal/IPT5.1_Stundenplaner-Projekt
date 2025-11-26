using System;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Schüler welcher in eine Schulklasse gehört, erbt von Person
    /// </summary>
    internal class Student : Person
    {
        /// <summary>
        /// Setzt Schüler, nimmt zwei Argumente an
        /// </summary>
        /// <param name="firstName">Vorname des Schülers</param>
        /// <param name="lastName">Nachname des Schülers</param>
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Setzt Schüler, nimmt drei Argumente an
        /// </summary>
        /// <param name="firstName">Vorname des Schülers</param>
        /// <param name="lastName">Nachname des Schülers</param>
        /// <param name="email">Email Adresse des Schülers</param>
        public Student(string firstName, string lastName, string email) : this(firstName,  lastName)
        {
            Email = email;
        }
    }
}