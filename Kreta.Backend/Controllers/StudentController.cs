using Kreta.Backend.Repos;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Models.SchoolCitizens;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo ?? throw new ArgumentException("Student repo nem létezik");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            StudentDto student = new StudentDto();
            if(_studentRepo is not null)
            {
                Student student = await _studentRepo.FindByCondition(student=>student.Id=id).FirstOrDefaultAsync();
                if (student != null)
                {
                    return Ok(student.ToDto);
                }
                else
                {
                    return Ok(new Student().ToDto);
                }
            }
            return BadRequest("Sikertelen lekérés");
        }
        public async Task<IActionResult> SelectStudentAsync()
        {
            List<StudentDto> studentsDtos = new List<StudentDto>();
            if (_studentRepo is not null)
            {
                List<Student> students = await _studentRepo.FindAll().ToListAsync();
                studentsDtos = students.Select(student => student.ToDto()).ToList();
                return Ok(studentsDtos);
            }
            return BadRequest("A diákadatok lekérése sikertelen!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(StudentDto student)
        {
            ControllerResponse response = new ControllerResponse();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.UpdateAsync(student.DtoToStuden());
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }
        [HttpPost()]
        public async Task<IActionResult> InsertStudentAsync(StudentDto student)
        {
            ControllerResponse response = null;

            if (student != null)
            {
                response=await _studentRepo.CreateAsync
                return Ok(student.ToDto);
            }
            else
            {
                return Ok(new Student().ToDto);
            }
        }
    }
}
