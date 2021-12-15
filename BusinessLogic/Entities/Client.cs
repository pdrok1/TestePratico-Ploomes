using BusinessLogic.Abstract;
using System.Collections.Generic;

namespace BusinessLogic.Entities
{
    public class Client : IEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Nickname { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public bool Enabled { get; set; }
    }
}
