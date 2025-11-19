using System;

namespace Stundenplaner_Projekt
{
    internal class Combination
    {
        public Subject Subject { get; }
        public Teacher Teacher { get; }
        public Room Room { get; }
        public TimeBlock Time { get; }
        public Combination(Subject subject, Teacher teacher, Room room, TimeBlock time)
        {
            this.Subject = subject;
            this.Teacher = teacher;
            this.Room = room;
            this.Room = room;
            this.Time = time;
        }
    }
}
