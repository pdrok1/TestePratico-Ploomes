using Infrastructure.Abstract;

namespace Infrastructure.Dtos.Messages
{
    public class TypeDto : IMongoDBDocument
    {
        public int Id { get; set; }

        public string Label { get; set; }
    }
}
