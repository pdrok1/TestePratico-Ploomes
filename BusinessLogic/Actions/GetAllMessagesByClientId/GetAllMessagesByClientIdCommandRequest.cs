using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetAllMessagesByClientId
{
    public class GetAllMessagesByClientIdCommandRequest : IRequest<GetAllMessagesByClientIdCommandResponse>
    {
        public int ClientId { get; set; }

        public GetAllMessagesByClientIdCommandRequest(int clientId)
        {
            ClientId = clientId;
        }
    }
}
