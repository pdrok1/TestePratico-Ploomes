using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetAllMessagesByClientId
{
    public class GetAllMessagesByClientIdCommandHandler : IRequestHandler<GetAllMessagesByClientIdCommandRequest, GetAllMessagesByClientIdCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetAllMessagesByClientIdCommandHandler(
            IMessageRepository messageRepository
        )
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetAllMessagesByClientIdCommandResponse> Handle(GetAllMessagesByClientIdCommandRequest request, CancellationToken cancellationToken)
        {
            return new GetAllMessagesByClientIdCommandResponse()
            {
                result = (await _messageRepository.GetAllMessagesBy(request.ClientId)).ToList()
            };
        }
    }
}
