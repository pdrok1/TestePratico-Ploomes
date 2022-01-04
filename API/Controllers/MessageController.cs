using BusinessLogic.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Actions.CreateMessage;
using MediatR;
using BusinessLogic.Actions.GetAllMessagesByClientId;
using System.Collections.Generic;
using BusinessLogic.Actions.GetMessagesWithTitle;
using BusinessLogic.Actions.GetMessagesContainingTitle;
using BusinessLogic.Actions.GetMessagesFromClientsWithContact;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerDefault
    {
        public MessageController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(Message), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("GetAllMessagesByClientId/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMessagesByClientId([FromRoute] int id)
        {
            return Ok((await _mediator.Send(new GetAllMessagesByClientIdCommandRequest(id))).result);
        }

        [HttpGet("GetMessagesFromClientsWithContact")]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessagesFromClientsWithContact([FromRoute] BusinessLogic.Entities.Contacts.TypeEnum contactType)
        {
            return Ok((await _mediator.Send(new GetMessagesFromClientsWithContactCommandRequest(contactType))).result);
        }

        [HttpGet("GetMessagesWithTitle")]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessagesWithTitle([FromQuery] string title)
        {
            return Ok((await _mediator.Send(new GetMessagesWithTitleCommandRequest(title))).result);
        }

        [HttpGet("GetMessagesContainingTitle")]
        [ProducesResponseType(typeof(IEnumerable<Message>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMessagesContainingTitle([FromQuery] string title)
        {
            return Ok((await _mediator.Send(new GetMessagesContainingTitleCommandRequest(title))).result);
        }
    }
}
