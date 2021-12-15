using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using BusinessLogic.Repositories;
using Infrastructure.Abstract;
using Infrastructure.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MessageRepository : GenericMongoDBRepository<Message, MessageDto>, IMessageRepository
    {
        public MessageRepository(IOptions<MongoDBSettings> settings) : base(settings) 
        { }

        public async Task<IQueryable<Message>> GetAllMessagesBy(int clientId)
        {
            return (await _collection.FindAsync(Builders<MessageDto>.Filter.Eq(doc => doc.ReceiverId, clientId)))
                .ToList().Select(m => ToDomain(m)).AsQueryable();
        }

        public Task<IQueryable<Message>> GetAllMessagesBy(int clientId, TypeEnum type)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IQueryable<Message>> GetAllMessagesBy(string title)
        {
            return (await _collection.FindAsync(Builders<MessageDto>.Filter.Eq(doc => doc.Title, title)))
                .ToList().Select(m => ToDomain(m)).AsQueryable();
        }

        public async Task<IQueryable<Message>> GetAllMessagesWithSubString(string titleSubString)
        {
            var pipeline = PipelineDefinition<MessageDto, MessageDto>.Create(
                new BsonDocument[] { new BsonDocument("Title", new BsonDocument("$regex", titleSubString)) 
            });

            return (await _collection.AggregateAsync(pipeline)).ToList().Select(m => ToDomain(m)).AsQueryable();
        }
    }
}
