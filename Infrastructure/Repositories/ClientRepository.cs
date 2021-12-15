using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using BusinessLogic.Repositories;
using Infrastructure.Abstract;
using Infrastructure.Dtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : GenericMongoDBRepository<Client, ClientDto>, IClientRepository
    {
        public ClientRepository(IOptions<MongoDBSettings> settings, CounterRepository counterRepository) : base(settings, counterRepository)
        { 
        }

        public async Task<bool> ModifyEnabledField(int id, bool enabledValue)
        {
            var filterDefinition = Builders<ClientDto>.Filter.Eq(doc => doc.Id, id);

            var clientDocument = (await _collection.FindAsync(filterDefinition)).FirstOrDefault();

            if (clientDocument is null)
                return false;

            if (clientDocument.Enabled == enabledValue)
                return true;

            clientDocument.Enabled = enabledValue;

            return (await _collection.ReplaceOneAsync(filterDefinition, clientDocument)).ModifiedCount == 1;
        }

        public Task<bool> Disable(int id)
            => ModifyEnabledField(id, false);

        public Task<bool> Enable(int id)
            => ModifyEnabledField(id, true);

        public Task<IQueryable<Client>> GetAll(bool includeDisabled = false)
        {
            return Task.Run(() => 
                !includeDisabled
                ? _collection.Find(Builders<ClientDto>.Filter.Eq(doc => doc.Enabled, true)).ToEnumerable().AsQueryable().Select(doc => ToDomain(doc))
                : _collection.AsQueryable().Select(doc => ToDomain(doc))
            );
        }

        public Task<IQueryable<Client>> GetAllDisabled()
        {
            return Task.Run(() => 
                _collection.Find(Builders<ClientDto>.Filter.Eq(doc => doc.Enabled, false)).ToEnumerable().AsQueryable().Select(doc => ToDomain(doc))
            );
        }

        public Task<IQueryable<Client>> GetAllWith(TypeEnum type)
        {
            return Task.Run(() =>
                _collection.Find(
                    Builders<ClientDto>.Filter.ElemMatch(
                        doc => doc.Contacts,
                        Builders<ContactDto>.Filter.Eq(contactDoc => contactDoc.TypeId, (int)type)
                    )
                ).ToEnumerable().Select(doc => ToDomain(doc)).AsQueryable()
            );
        }
    }
}
