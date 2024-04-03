using Academy.Application.Commands.CreateInstructorCommand;
using Academy.Application.Commands.LoginInstructorCommand;
using Academy.Application.Queries.GetInstructorQuery;
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
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMediator _mediator;

        public InstructorController(IInstructorRepository instructorRepository, IMediator mediator)
        {
            _instructorRepository = instructorRepository;
            _mediator = mediator;
        }

        [HttpPut("login")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> Login([FromBody] LoginInstructorCommand command)
        {
            var loginInstructorviewModel = await _mediator.Send(command);

            if (loginInstructorviewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginInstructorviewModel);
        }

        [HttpGet]
        [Authorize(Roles = "instructor")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var instructors = await _instructorRepository.GettAllAsync();
                return Ok(instructors);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Could not find all instructors");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> GettByIdAsync(int id)
        {
            var query = new GetInstructorQuery(id);

            try
            {
                var instructor = await _mediator.Send(query);
                if (instructor != null)
                {
                    return NotFound("The data does not exist!");
                }

                return Ok(instructor);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error getting the data provided!");
            }
        }

        [HttpPost]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> AddInstructorCommand(CreateInstructorCommand command)
        {
            try
            {
                if (command == null)
                {
                    return BadRequest("The data does not exist!");
                }

                var id = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetInstructorQuery), new { id = id }, command);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Unable to add instructor!");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> UpdateAsync(int id, Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest("Id not found!");
            }

            try
            {
                await _instructorRepository.UpdateAsync(instructor);
                return Ok(instructor);
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
                var instructorToDelete = await _instructorRepository.GettByIdAsync(id);
                if (instructorToDelete == null)
                {
                    return NotFound($"Instructor with id: {id} was not found!");
                }

                await _instructorRepository.DeleteAsync(id);
                return Ok(instructorToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error when deleting instructor with id: {id}");
            }
        }
    }
}
