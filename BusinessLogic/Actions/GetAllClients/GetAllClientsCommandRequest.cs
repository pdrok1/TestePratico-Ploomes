using BusinessLogic.Actions.CreateMessage;
using MediatR;

namespace BusinessLogic.Actions.GetAllClients
{
    public class GetAllClientsCommandRequest : IRequest<GetAllClientsCommandResponse>
    {
        public bool ShowDisabled { get; set; }

        public bool ShowOnlyDisabled { get; set; }

        public GetAllClientsCommandRequest(bool showDisabled, bool showOnlyDisabled)
        {
            ShowDisabled = showDisabled;
            ShowOnlyDisabled = showOnlyDisabled;
        }
    }
}
