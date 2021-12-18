using BusinessLogic.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesWithTitle
{
    public class GetMessagesWithTitleCommandHandler : IRequestHandler<GetMessagesWithTitleCommandRequest, GetMessagesWithTitleCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesWithTitleCommandHandler(
            IMessageRepository messageRepository
        )
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetMessagesWithTitleCommandResponse> Handle(GetMessagesWithTitleCommandRequest request, CancellationToken cancellationToken)
        {
            return new GetMessagesWithTitleCommandResponse() 
            { 
                result = (await _messageRepository.GetAllMessagesBy(request.TitleQuery)).ToList() 
            };
        }
    }
}
