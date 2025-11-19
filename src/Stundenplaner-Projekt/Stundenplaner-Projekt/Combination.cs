using System;

namespace Stundenplaner_Projekt
{
    public class Combination
    {
        public Subject Subject { get; init; }
        public Teacher Teacher { get; init; }
        public Room Room { get; init; }
        public TimeBlock Time { get; init; }
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
