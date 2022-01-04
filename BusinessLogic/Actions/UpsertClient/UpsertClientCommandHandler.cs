using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using BusinessLogic.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.UpsertClient
{
    public class UpsertClientCommandHandler : IRequestHandler<UpsertClientCommandRequest, UpsertClientCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        public UpsertClientCommandHandler(
               IClientRepository clientRepository
           )
        {
            _clientRepository = clientRepository;
        }

        public async Task<UpsertClientCommandResponse> Handle(UpsertClientCommandRequest request, CancellationToken cancellationToken)
        {
            var newClientData = new Client()
            {
                FullName = request.FullName,
                Nickname = request.Nickname,
                Contacts = request.Contacts
            };

            if (request.Contacts != null)
            {
                newClientData.Contacts = new List<Contact>();
                int index = 0;
                foreach (var contact in request.Contacts)
                {
                    if(!string.IsNullOrEmpty(contact.Value))
                        newClientData.Contacts.Add(new Contact() { Id = ++index, TypeId = contact.TypeId, Value = contact.Value });
                }
            }

            var currentClient = await _clientRepository.GetBy(request.Id);
            if (currentClient is null)
            {
                newClientData.Enabled = true;
                return await _clientRepository.Insert(newClientData) as UpsertClientCommandResponse;
            }

            newClientData.Enabled = currentClient.Enabled;
            return await _clientRepository.Update(request.Id, newClientData) as UpsertClientCommandResponse;
        }
    }
}
