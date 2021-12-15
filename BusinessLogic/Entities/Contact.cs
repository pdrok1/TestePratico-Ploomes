using BusinessLogic.Abstract;

namespace BusinessLogic.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Value { get; set; }

    }
}
