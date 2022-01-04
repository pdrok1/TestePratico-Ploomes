using BusinessLogic.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesContainingTitle
{
    public class GetMessagesContainingTitleCommandHandler : IRequestHandler<GetMessagesContainingTitleCommandRequest, GetMessagesContainingTitleCommandResponse>
    {
        private readonly IMessageRepository _messageRepository;

        public GetMessagesContainingTitleCommandHandler(
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
