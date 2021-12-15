using BusinessLogic.Abstract;
using Infrastructure.Attributes;
using Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Abstract
{
    public abstract class GenericMongoDBRepository<TEntity, TDocument> : GenericMongoDBClient<TDocument>, IRepository<TEntity>
        where TEntity : class, IEntity
        where TDocument : class, IMongoDBDocument
    {
        private readonly CounterRepository _counterRepository;

        public GenericMongoDBRepository(IOptions<MongoDBSettings> settings, CounterRepository counterRepository) : base(settings)
        {
            _counterRepository = counterRepository;
        }

        protected TDocument ToDto(TEntity entity)
            => entity is not null ? Utils.CallExtensionMethod<TDocument>(thisAssembly, entity, "ToDto") : default;

        protected TEntity ToDomain(TDocument document)
            => document is not null ? Utils.CallExtensionMethod<TEntity>(thisAssembly, document, "ToDomain") : default;



        public void Dispose() 
        {
            GC.Collect();
        }



        public async Task<TEntity> GetBy(int id)
            => id > 0 ? ToDomain(await _collection.Find(Builders<TDocument>.Filter.Eq(doc => doc.Id, id)).FirstOrDefaultAsync()) : null;

        public virtual async Task<TEntity> Insert(TEntity newEntity)
        {
            newEntity.Id = await _counterRepository.GetNextId();
            await _collection.InsertOneAsync(ToDto(newEntity));
            return newEntity;
        }

        public virtual async Task<TEntity> Update(int id, TEntity newEntity)
        {
            if (id > 0)
            {
                await _collection.FindOneAndReplaceAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, id), ToDto(newEntity));
                return newEntity;
            }

            return null;
        }

        public virtual async Task<bool> RemoveBy(int id)
            => id > 0 ? (await _collection.DeleteOneAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, id))).DeletedCount == 1 : false;

    }
}
