using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Models.SchoolCitizens
{
    public class Teacher : IDbEntity<Teacher>
    {
        public Teacher(Guid id, string firstName, string lastName, DateTime birthsDay, string educationLevel, bool isWooman)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            EducationLevel = educationLevel;
            IsWoomen = isWooman;
        }
        public Teacher(string firstName, string lastName, DateTime birthsDay, int schoolYear, SchoolClassType schoolClass, string educationLevel, bool isWooman)
        {
            Id = new Guid();
            FirstName = firstName;
            LastName = lastName;
            BirthsDay = birthsDay;
            EducationLevel = educationLevel;
            IsWoomen = isWooman;
        }

        public Teacher()
        {
            Id = new Guid();
            FirstName = string.Empty;
            LastName = string.Empty;
            BirthsDay = new DateTime();
            EducationLevel = string.Empty;
            IsWoomen = false;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthsDay { get; set; }
        public string EducationLevel { get; set; }
        public bool IsWoomen { get; set; }

        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName}, Szül: ({String.Format("{0:yyyy.MM.dd.}", BirthsDay)}), Tanulmányi szint: ({EducationLevel})";
        }

    }
}
