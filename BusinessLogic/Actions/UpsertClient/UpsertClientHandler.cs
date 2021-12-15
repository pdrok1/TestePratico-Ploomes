using BusinessLogic.Entities;
using BusinessLogic.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.UpsertClient
{
    public class UpsertClientHandler : IRequestHandler<UpsertClientRequest, UpsertClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        public UpsertClientHandler(
               IClientRepository clientRepository
           )
        {
            _clientRepository = clientRepository;
        }

        public async Task<UpsertClientResponse> Handle(UpsertClientRequest request, CancellationToken cancellationToken)
        {
            var newClientData = new Client()
            {
                FullName = request.FullName,
                Nickname = request.Nickname,
                Contacts = request.Contacts
            };

            var currentClient = await _clientRepository.GetBy(request.Id);
            if (currentClient is null)
            {
                newClientData.Enabled = true;
                return await _clientRepository.Insert(newClientData) as UpsertClientResponse;
            }

            return await _clientRepository.Update(request.Id, newClientData) as UpsertClientResponse;
        }
    }
}
