using MediatR;

namespace BusinessLogic.Actions.CreateMessage
{
    public class CreateMessageRequest : IRequest<CreateMessageResponse>
    {
        public int Id { get; set; }

        public int ReceiverId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
