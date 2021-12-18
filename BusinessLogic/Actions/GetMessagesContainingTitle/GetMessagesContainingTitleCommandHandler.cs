using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesContainingInTitle
{
    public class GetMessagesContainingTitleCommandHandler : IRequestHandler<GetMessagesContainingTitleCommandRequest, GetMessagesContainingTitleCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesFromClientsWithContactCommandHandler(
            IMessageRepository messageRepository
        )
        {
            _messageRepository = messageRepository;
        }

        public async Task<GetMessagesContainingTitleCommandResponse> Handle(GetMessagesContainingTitleCommandRequest request, CancellationToken cancellationToken)
        {
            return new GetMessagesContainingTitleCommandResponse()
            {
                result = (await _messageRepository.GetAllMessagesWithSubString(request.TitleQuery)).ToList()
            };
        }
    }
}
