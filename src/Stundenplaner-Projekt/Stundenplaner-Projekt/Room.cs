using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
                _maxStudent = value;
            }
        }
        public Room(string roomId)
        {
            _roomId = roomId;
        }
        public Room(string roomId, int maxStudent)
        {
            _roomId = roomId;
            _maxStudent = maxStudent;
        }
    }
}