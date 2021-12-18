using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetClientById
{
    public class GetClientByIdCommandRequest : IRequest<GetClientByIdCommandResponse>
    {
        public int Id { get; set; }

        public GetClientByIdCommandRequest(int id)
        {
            Id = id;
        }
    }
}
