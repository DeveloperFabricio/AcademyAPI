using Academy.Application.Commands.CresteStudentCommand;
using Academy.Application.Queries.GetStudentQuery;
using Academy.Core.Entities;
using Academy.Core.Interface;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediator _mediator;

        public StudentController(IStudentRepository studentRepository, IMediator mediator)
        {
            _studentRepository = studentRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "instructor")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _studentRepository.GetAllAsync();
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Could not find all students");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> GettByIdAsync(int id)
        {
            var query = new GetStudentQuery(id);

            try
            {
                var students = await _mediator.Send(query);
                if (students != null)
                {
                    return NotFound("The data does not exist!");
                }

                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error getting the data provided!");
            }
        }

        [HttpPost]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> AddStudentCommand(CreateStudentCommand student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("The data does not exist!");
                }

                var id = await _mediator.Send(student);
                return CreatedAtAction(nameof(GetStudentQuery), new { id = id }, student);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Unable to add student!");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> UpdateAsync(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Id not found!");
            }

            try
            {
                await _studentRepository.UpdateAsync(student);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error updating!");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> DeleteAasync(int id)
        {
            try
            {
                var studentToDelete = await _studentRepository.GetByIdAsync(id);
                if (studentToDelete == null)
                {
                    return NotFound($"Student with id: {id} was not found!");
                }

                await _studentRepository.DeleteAsync(id);
                return Ok(studentToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error when deleting student with id: {id}");
            }
        }

    }
}
