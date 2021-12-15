using Infrastructure.Abstract;
using Infrastructure.Attributes;

namespace Infrastructure.Dtos
{
    [CollectionName("Message")]
    public class MessageDto : IMongoDBDocument
    {
        public int Id { get; set; }

        public int ReceiverId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
