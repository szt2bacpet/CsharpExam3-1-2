using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SchoolCitizens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Shared.Extensions
{
    public static class TeacherExtension
    {
        public static TeacherDto ToDto(this Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                BirthsDay = teacher.BirthsDay,
                EducationLevel = teacher.EducationLevel,
                IsWoomen = teacher.IsWoomen,
            };
        }

        public static Teacher DtoToStuden(this TeacherDto teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                BirthsDay = teacherDto.BirthsDay,
                EducationLevel = teacherDto.EducationLevel,
                IsWoomen = teacherDto.IsWoomen,
            };
        }
    }
}
