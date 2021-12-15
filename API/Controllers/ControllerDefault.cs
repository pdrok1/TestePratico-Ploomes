using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ControllerDefault : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ControllerDefault(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
