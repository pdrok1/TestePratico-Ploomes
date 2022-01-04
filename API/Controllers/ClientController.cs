using BusinessLogic.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Actions.UpsertClient;
using BusinessLogic.Actions.SetClientEnabled;
using BusinessLogic.Actions.GetAllClients;
using BusinessLogic.Actions.GetAllClientsWithContact;
using BusinessLogic.Actions.GetClientById;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerDefault
    {
        public ClientController(IMediator mediator) : base(mediator) { }

        private async Task<IActionResult> UpsertClient(UpsertClientCommandRequest request, int? id)
        {
            request.Id = id ?? 0;
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateClient([FromBody] UpsertClientCommandRequest request)
        {
            return await UpsertClient(request, null);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateClient([FromBody] UpsertClientCommandRequest request, [FromRoute] int? id)
        {
            return await UpsertClient(request, id);
        }

        [HttpPatch("Enable/{id}")]
        public async Task<IActionResult> Enable([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new SetClientEnabledCommandRequest(id, true)));
        }

        [HttpPatch("Disable/{id}")]
        public async Task<IActionResult> Disable([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new SetClientEnabledCommandRequest(id, false)));
        }

        [HttpGet("GetAllClients")]
        [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllClients([FromQuery] bool showDisabled, [FromQuery] bool showOnlyDisabled)
        {
            return Ok((await _mediator.Send(new GetAllClientsCommandRequest(showDisabled, showOnlyDisabled))).result);
        }

        [HttpGet("GetAllClientsWithContact")]
        [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllClientsWithContact([FromQuery] BusinessLogic.Entities.Contacts.TypeEnum contactType)
        {
            return Ok((await _mediator.Send(new GetAllClientsWithContactCommandRequest(contactType))).result);
        }

        [HttpGet("GetClientById/{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetClientById([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetClientByIdCommandRequest(id)));
        }
    }
}
