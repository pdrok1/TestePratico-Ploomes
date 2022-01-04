using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BusinessLogic.Actions.GetAllClientsWithContact
{
    public class GetAllClientsWithContactCommandRequest : IRequest<GetAllClientsWithContactCommandResponse>
    {
        public Entities.Contacts.TypeEnum ContactType { get; set; }

        public GetAllClientsWithContactCommandRequest(Entities.Contacts.TypeEnum contactType)
        {
            ContactType = contactType;
        }
    }
}
