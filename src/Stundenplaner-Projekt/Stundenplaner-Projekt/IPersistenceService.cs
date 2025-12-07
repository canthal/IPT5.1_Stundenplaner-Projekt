using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stundenplaner_Projekt
{
    internal interface IPersistenceService
    {
        string BasePath { get; }

        void SaveData(List<Room> rooms);

        void SaveData(List<SchoolClass> schoolClasses);

        void SaveData(List<Student> students);

        void SaveData(List<Subject> subjects);

        List<Room> LoadDataRoom();

        List<SchoolClass> LoadDataSchoolClass();

        List<Student> LoadDataStudent();

        List<Subject> LoadDataSubject();
    }
}
