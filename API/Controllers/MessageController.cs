using BusinessLogic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Actions.CreateMessage;
using MediatR;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerDefault
    {
        public MessageController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
