using BusinessLogic.Abstract;
using BusinessLogic.Entities.Contacts;

namespace BusinessLogic.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        public TypeEnum TypeId { get; set; }

        public string Value { get; set; }

    }
}
