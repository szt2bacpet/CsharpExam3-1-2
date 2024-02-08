using Kreta.Shared.Models.SchoolCitizens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Dtos
{
    public class TeacherDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthsDay { get; set; } = DateTime.MinValue;
        public string EducationLevel { get; set; } = string.Empty;
        public bool IsWoomen { get; set; } = false;

        public Teacher DtoToTeacher()
        {
            throw new NotImplementedException();
        }
    }
}
