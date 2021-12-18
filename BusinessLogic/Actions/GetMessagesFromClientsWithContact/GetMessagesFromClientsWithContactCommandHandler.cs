using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesFromClientsWithContact
{
    public class GetMessagesFromClientsWithContactCommandHandler : IRequestHandler<GetMessagesFromClientsWithContactCommandRequest, GetMessagesFromClientsWithContactCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesFromClientsWithContactCommandHandler(
            IMessageRepository messageRepository
        )
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetMessagesFromClientsWithContactCommandResponse> Handle(GetMessagesFromClientsWithContactCommandRequest request, CancellationToken cancellationToken)
        {
            return new GetMessagesFromClientsWithContactCommandResponse()
            {
                result = (await _messageRepository.GetAllMessagesBy(request.ContactType)).ToList()
            };
        }
    }
}
