using System.Text.Json.Serialization;

namespace Stundenplaner_Projekt
{
    /// <summary>
    /// TimetableJSON wird für das Speichern von Stundeplänen verwendet
    /// </summary>
    public class TimetableJSON
    {
        public TimeBlock Block { get; set; }
        public Combination Combination { get; set; }

        /// <summary>
        /// Standardkonstruktor, welcher für das Serializieren von JSON Dateien verwendet wird
        /// </summary>
        [JsonConstructor]
        public TimetableJSON() 
        {
        }

        /// <summary>
        /// Setzt die zwei Propertys welcher dann gespeichert wird
        /// </summary>
        /// <param name="block">Die Zeit von der Combination</param>
        /// <param name="combination">Combination welche gespeichert werden soll</param>
        public TimetableJSON(TimeBlock block, Combination combination)
        {
            Block = block;
            Combination = combination;
        }
    }

}