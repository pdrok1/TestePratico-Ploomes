using Infrastructure.Abstract;
using Infrastructure.Attributes;

namespace Infrastructure.Dtos
{
    [CollectionName("_Counter")]
    public class CounterDto : IMongoDBDocument
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
