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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo _teacherRepo;
        public TeacherController(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo ?? throw new ArgumentException("Teacher repo nem létezik");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            TeacherDto teacher = new TeacherDto();
            if(_teacherRepo is not null)
            {
                Teacher teacher = await _teacherRepo.FindByCondition(teacher => teacher.Id = id).FirstOrDefaultAsync();
                if (teacher != null)
                {
                    return Ok(teacher.ToDto);
                }
                else
                {
                    return Ok(new Teacher().ToDto);
                }
            }
            return BadRequest("Sikertelen lekérés");
        }
        public async Task<IActionResult> SelectStudentAsync()
        {
            List<TeacherDto> teachersDtos = new List<TeacherDto>();
            if (_teacherRepo is not null)
            {
                List<Teacher> teachers = await _teacherRepo.FindAll().ToListAsync();
                teachersDtos = teachers.Select(teacher => teacher.ToDto()).ToList();
                return Ok(teachersDtos);
            }
            return BadRequest("A diákadatok lekérése sikertelen!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherAsync(TeacherDto teacher)
        {
            ControllerResponse response = new ControllerResponse();
            if (_teacherRepo is not null)
            {
                response = await _teacherRepo.UpdateAsync(teacher.DtoToStuden());
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
        public async Task<IActionResult> InsertTeacherAsync(TeacherDto teacher)
        {
            ControllerResponse response = null;

            if (teacher != null)
            {
                response=await _teacherRepo CreateAsync
                return Ok(teacher.ToDto);
            }
            else
            {
                return Ok(new Teacher().ToDto);
            }
        }
    }
}
