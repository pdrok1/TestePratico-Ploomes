using Infrastructure.Abstract;

namespace Infrastructure.Dtos.Contacts
{
    public class TypeDto : IMongoDBDocument
    {
        public int Id { get; set; }

        public int Label { get; set; }
    }
}
