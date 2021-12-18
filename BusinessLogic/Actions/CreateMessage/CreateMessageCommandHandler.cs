using BusinessLogic.Entities;
using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommandRequest, CreateMessageCommandResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateMessageCommandHandler(
            IClientRepository clientRepository,
            IMessageRepository messageRepository
        )
        {
            _clientRepository = clientRepository;
            _messageRepository = messageRepository;
        }

        public async Task<CreateMessageCommandResponse> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            var receiverClient = await _clientRepository.GetBy(request.ReceiverId);

            if(receiverClient is null) 
                throw new ApplicationException($"Invalid clientId {request.ReceiverId}");

            var newMessage = new Message()
            {
                ReceiverId = request.ReceiverId,
                Title = request.Title,
                Type = request.Type,
                Content = request.Content
            };

            return await _messageRepository.Insert(newMessage) as CreateMessageCommandResponse;
        }
    }
}
