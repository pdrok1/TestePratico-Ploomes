using BusinessLogic.Abstract;
using Infrastructure.Attributes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Abstract
{
    public abstract class GenericMongoDBRepository<TEntity, TDocument> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TDocument : class, IMongoDBDocument
    {

        private readonly Assembly thisAssembly = Assembly.Load(AssemblyName.GetAssemblyName(AppDomain.CurrentDomain.BaseDirectory + "Infrastructure.dll"));

        protected readonly IMongoCollection<TDocument> _collection;

        public GenericMongoDBRepository(IOptions<MongoDBSettings> settings)
        {
            var collectionName = typeof(TDocument).GetCustomAttribute<CollectionNameAttribute>()?.Value;

            if (collectionName is null)
                throw new NotSupportedException($"{typeof(TDocument).FullName} doesn't support a MongoCollection (doesn't have the CollectionName attribute)");

            _collection =
                new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"))
                .GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"))
                .GetCollection<TDocument>(collectionName);
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
