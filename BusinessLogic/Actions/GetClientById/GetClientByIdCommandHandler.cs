using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetClientById
{
    public class GetClientByIdCommandHandler : IRequestHandler<GetClientByIdCommandRequest, GetClientByIdCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdCommandHandler(
            IClientRepository clientRepository
        )
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetClientByIdCommandResponse> Handle(GetClientByIdCommandRequest request, CancellationToken cancellationToken)
        {
            return (GetClientByIdCommandResponse)await _clientRepository.GetBy(request.Id);
        }
    }
}
