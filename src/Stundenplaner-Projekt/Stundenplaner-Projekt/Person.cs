using System;

namespace Stundenplaner_Projekt
{
    public abstract class Person
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }
    }
}
