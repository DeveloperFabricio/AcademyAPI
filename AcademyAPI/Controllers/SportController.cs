using Academy.Application.Commands.CresteSportCommand;
using Academy.Application.Queries.GetSportQuery;
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
    public class SportController : ControllerBase
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMediator _mediator;

        public SportController(ISportRepository sportRepository, IMediator mediator)
        {
            _sportRepository = sportRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "instructor")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sports = await _sportRepository.GetAllAsync();
                return Ok(sports);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Could not find all sports");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> GettByIdAsync(int id)
        {
            var query = new GetSportQuery(id);

            try
            {
                var sports = await _mediator.Send(query);
                if (sports != null)
                {
                    return NotFound("The data does not exist!");
                }

                return Ok(sports);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error getting the data provided!");
            }
        }

        [HttpPost]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> AddSportCommand(CreateSportCommand sport)
        {
            try
            {
                if (sport == null)
                {
                    return BadRequest("The data does not exist!");
                }

                var id = await _mediator.Send(sport);
                return CreatedAtAction(nameof(GetSportQuery), new { id = id }, sport);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Unable to add sport!");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "instructor")]
        public async Task<IActionResult> UpdateAsync(int id, Sport sport)
        {
            if (id != sport.Id)
            {
                return BadRequest("Id not found!");
            }

            try
            {
                await _sportRepository.UpdateAsync(sport);
                return Ok(sport);
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
                var sportToDelete = await _sportRepository.GettByIdAsync(id);
                if (sportToDelete == null)
                {
                    return NotFound($"Sport with id: {id} was not found!");
                }

                await _sportRepository.DeleteAsync(id);
                return Ok(sportToDelete);
            }
            catch (Exception)
            {
                return StatusCode(500, $"Error when deleting sport with id: {id}");
            }
        }
    }
}
