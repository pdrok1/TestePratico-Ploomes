using Infrastructure.Abstract;
using System.Collections.Generic;
using Infrastructure.Attributes;

namespace Infrastructure.Dtos
{
    [CollectionName("Client")]
    public class ClientDto : IMongoDBDocument
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Nickname { get; set; }

        public ICollection<ContactDto> Contacts { get; set; }

        public bool Enabled { get; set; }
    }
}
