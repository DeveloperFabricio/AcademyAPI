using Academy.Application.Commands.PaymentStudentCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{id}/payments")]
        [Authorize(Roles = "instructor")]

        public async Task<IActionResult> Payment(int id, PaymentStudentCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("Payment cannot be processed!");
            }

            return Accepted();
        }
    }
}
