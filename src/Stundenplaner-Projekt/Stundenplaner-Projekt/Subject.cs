using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt 
{
    /// <summary>
    /// Fach welches von Lehrern unterrichtet wird
    /// </summary>
    internal class Subject
    {
        /// <summary>
        /// Speicher für den Namen des Faches
        /// </summary>
        private string _name;

        /// <summary>
        /// Property regelt zugriff auf das Feld _name überprüft, ob Name nicht leer ist
        /// </summary>
        public string Name 
        { 
            get => _name;
            set 
            {
                if (value.Length == 0) throw new FormatException("Name darf nicht die Länge 0 haben!");
                _name = value;
            }
        }

        /// <summary>
        /// Setzt Fach mit einem Attribut namens Name
        /// </summary>
        /// <param name="name">Name des Faches</param>
        public Subject(string name)
        {
            Name = name;
        }
    }
}

