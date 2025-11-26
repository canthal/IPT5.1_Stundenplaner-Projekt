using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Stundenplaner_Projekt
{
    internal class Room
    {
        private string _roomId;
        private int _maxStudent;
        public string RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                if (value.Length == 0) throw new FormatException("Der Raum muss einen Namen länger als 0 Zeichen haben");
                _roomId = value;
            }
        }
        public int MaxStudent
        {
            get
            {
                return _maxStudent;
            }
            set
            {
                if (value < 0) throw new FormatException("Ein Raum darf keine negativen maxStudent haben!");
                _maxStudent = value;
            }
        }
        [JsonConstructor]
        public Room(string roomId)
        {
            RoomId = roomId;
        }
        public Room(string roomId, int maxStudent)
        {
            RoomId = roomId;
            MaxStudent = maxStudent;
        }
    }
}