namespace Stundenplaner_Projekt
{
    internal class Student : Person
    {
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Student(string firstName, string lastName, string email) : this(firstName,  lastName)
        {
            Email = email;
        }
    }
}