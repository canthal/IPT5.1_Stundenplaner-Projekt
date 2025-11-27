using System;
using System.Text.Json.Serialization;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// TimeBlock wird benutzt um die Zeiten festzuhalten wo Lehrer verfügbar sind, und wann unterricht ist
    /// </summary>
    public class TimeBlock
    {
        /// <summary>
        /// Auswahl welcher Schultag betroffen ist
        /// </summary>
        public enum Weekday { Montag = 1, Dienstag = 2, Mittwoch = 3, Donnerstag = 4, Freitag = 5 }

        /// <summary>
        /// Auswahl welche Zeit die Verfügbarkeit herrscht
        /// </summary>
        public readonly static string[] Hours =
        {
            "8:00 - 9:00",
            "9:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "15:00 - 16:00",
            "16:00 - 17:00"
        };

        /// <summary>
        /// Gibt die gesammten Arbeitstunden wider 
        /// </summary>
        public static int WorkHours { get; } = Hours.Length;
        /// <summary>
        /// Gibt den Tag zurück
        /// </summary>
        public Weekday Day { get; }
        /// <summary>
        /// Gibt den Index von der Stunde zurück
        /// </summary>
        public int BlockIndex { get; }
        /// <summary>
        /// Gibt den die Stunde zurück als Textform
        /// </summary>
        public string GetHours => Hours[BlockIndex];

        /// <summary>
        /// Setzt TimeBlock mit einem Parameter
        /// </summary>
        /// <param name="weekday">Welcher arbeitstag betroffen ist</param>
        public TimeBlock(Weekday day)
        {
            Day = day;
        }

        /// <summary>
        /// Setzt TimeBlock mit zwei Parametern
        /// </summary>
        /// <param name="weekday">Welcher arbeitstag betroffen ist</param>
        /// <param name="blockIndex">Welche Stunde betroffen ist</param>
        [JsonConstructor]
        public TimeBlock(Weekday day, int blockIndex) : this(day)
        {
            BlockIndex = blockIndex;
        }
    }
}
