using Infrastructure.Abstract;

namespace Infrastructure.Dtos
{
    public class ContactDto : IMongoDBDocument
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Value { get; set; }

    }
}
