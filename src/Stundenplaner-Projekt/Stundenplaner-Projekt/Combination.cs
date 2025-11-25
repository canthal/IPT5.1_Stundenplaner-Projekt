using System;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// Klasse die die Beziehungen zwischen weiteren Klassen auffasst, um für den Algorithmus Informationen zur verfügung zu stellen.
    /// </summary>
    internal class Combination
    {
        /// <summary>
        /// Fach, welches für interne Zwecke verwendet wird.
        /// </summary>
        public Subject Subject { get; }
        /// <summary>
        /// Lehrer, welches für interne Zwecke verwendet wird.
        /// </summary>
        public Teacher Teacher { get; }
        /// <summary>
        /// Raum, welches für interne Zwecke verwendet wird.
        /// </summary>
        public Room Room { get; }
        /// <summary>
        /// Zeit, welches für interne Zwecke verwendet wird.
        /// </summary>
        public TimeBlock Time { get; }

        /// <summary>
        /// Fasst die Beziehungen zwischen 4 Klassen auf.
        /// </summary>
        /// <param name="subject">Fach welches der Lehrer unterrichtet</param>
        /// <param name="teacher">Lehrer der die Unterrichtlektion übernimmt</param>
        /// <param name="room">der Raum in dem die Lektion stattfindet</param>
        /// <param name="time">die Zeit an dem der Unterricht stattfindet</param>
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
