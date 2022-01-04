using MediatR;

namespace BusinessLogic.Actions.GetMessagesContainingTitle
{
    public class GetMessagesContainingTitleCommandRequest : IRequest<GetMessagesContainingTitleCommandResponse>
    {
        public string TitleQuery { get; set; }

        public GetMessagesContainingTitleCommandRequest(string titleQuery)
        {
            TitleQuery = titleQuery;
        }
    }
}
