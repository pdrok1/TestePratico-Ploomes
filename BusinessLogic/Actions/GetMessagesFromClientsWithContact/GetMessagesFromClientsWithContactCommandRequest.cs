using BusinessLogic.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Actions.GetMessagesFromClientsWithContact
{
    public class GetMessagesFromClientsWithContactCommandRequest : IRequest<GetMessagesFromClientsWithContactCommandResponse>
    {
        public Entities.Contacts.TypeEnum ContactType { get; set; }

        public GetMessagesFromClientsWithContactCommandRequest(Entities.Contacts.TypeEnum contactType)
        {
            ContactType = contactType;
        }
    }
}
