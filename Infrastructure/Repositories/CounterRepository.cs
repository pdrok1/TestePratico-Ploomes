using Infrastructure.Abstract;
using Infrastructure.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CounterRepository : GenericMongoDBClient<CounterDto>
    {
        public CounterRepository(IOptions<MongoDBSettings> settings) : base(settings)
        {
        }

        public async Task<int> GetNextId()
        {
            var counter = (await _collection.FindAsync(Builders<CounterDto>.Filter.Eq(doc => doc.Id, 1))).FirstOrDefault();
            counter.Value += 1;
            await _collection.FindOneAndReplaceAsync<BsonDocument>(Builders<CounterDto>.Filter.Eq(doc => doc.Id, 1), counter);
            return counter.Value - 1;
        }
    }
}
