using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetAllClientsWithContact
{
    public class GetAllClientsWithContactCommandHandler : IRequestHandler<GetAllClientsWithContactCommandRequest, GetAllClientsWithContactCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsWithContactCommandHandler(
            IClientRepository clientRepository
        )
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetAllClientsWithContactCommandResponse> Handle(GetAllClientsWithContactCommandRequest request, CancellationToken cancellationToken)
        {
            return new GetAllClientsWithContactCommandResponse()
            {
                result = (await _clientRepository.GetAllWith(request.ContactType)).ToList()
            };
        }
    }
}
