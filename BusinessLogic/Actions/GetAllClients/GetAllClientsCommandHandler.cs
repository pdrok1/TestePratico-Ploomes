using BusinessLogic.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetAllClients
{
    public class GetAllClientsCommandHandler : IRequestHandler<GetAllClientsCommandRequest, GetAllClientsCommandResponse>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsCommandHandler(
            IClientRepository clientRepository
        )
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetAllClientsCommandResponse> Handle(GetAllClientsCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllClientsCommandResponse();

            if (request.ShowOnlyDisabled)
                response.list = (await _clientRepository.GetAllDisabled()).ToList();
            else
                response.list = (await _clientRepository.GetAll(request.ShowDisabled)).ToList();

            return response;
        }
    }
}
