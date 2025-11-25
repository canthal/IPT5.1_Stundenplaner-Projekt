using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt 
{
    internal class Subject
    {
        private string _name;

        public string Name 
        { 
            get => _name;
            set 
            {
                if (value.Length == 0) throw new FormatException("Name darf nicht die Länge 0 haben!");
                _name = value;
            }
        }

        public Subject(string name)
        {
            Name = name;
        }
    }
}

