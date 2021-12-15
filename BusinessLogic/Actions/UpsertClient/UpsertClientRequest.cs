using BusinessLogic.Entities;
using MediatR;
using System.Collections.Generic;

namespace BusinessLogic.Actions.UpsertClient
{
    public class UpsertClientRequest : IRequest<UpsertClientResponse>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Nickname { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
