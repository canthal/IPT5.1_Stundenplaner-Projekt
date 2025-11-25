using System;

namespace Stundenplaner_Projekt
{
    public abstract class Person
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        public string FirstName
        {
            get => _firstName;
            set 
            {
                if (value.Length == 0) throw new FormatException("Die Länge des Namens darf nicht 0 sein!");
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length == 0) throw new FormatException("Die Länge des Namens darf nicht 0 sein!");
                _lastName = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value.Length == 0 && value.Contains("@")) throw new FormatException("Die Länge der E-Mail darf nicht 0 sein und muss ein @ beinhalten!");
                _email = value;
            }
        }
    }
}
