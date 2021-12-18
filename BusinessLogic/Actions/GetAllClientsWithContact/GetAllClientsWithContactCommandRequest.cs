using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
