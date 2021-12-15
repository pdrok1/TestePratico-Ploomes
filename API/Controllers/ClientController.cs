using BusinessLogic.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BusinessLogic.Actions.UpsertClient;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerDefault
    {
        public ClientController(IMediator mediator) : base(mediator) { }

        private async Task<IActionResult> UpsertClient(UpsertClientRequest request, int? id)
        {
            request.Id = id ?? 0;
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] UpsertClientRequest request)
        {
            return await UpsertClient(request, null);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        public async Task<IActionResult> Patch([FromBody] UpsertClientRequest request, [FromRoute] int? id)
        {
            return await UpsertClient(request, id);
        }
    }
}
