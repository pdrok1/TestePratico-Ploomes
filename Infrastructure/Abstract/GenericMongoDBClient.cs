using Infrastructure.Attributes;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Reflection;

namespace Infrastructure.Abstract
{
    public abstract class GenericMongoDBClient<TDocument>
        where TDocument : class, IMongoDBDocument
    {
        protected readonly Assembly thisAssembly = Assembly.Load(AssemblyName.GetAssemblyName(AppDomain.CurrentDomain.BaseDirectory + "Infrastructure.dll"));

        protected readonly IMongoCollection<TDocument> _collection;

        public GenericMongoDBClient(IOptions<MongoDBSettings> settings)
        {
            var collectionName = typeof(TDocument).GetCustomAttribute<CollectionNameAttribute>()?.Value;

            if (collectionName is null)
                throw new NotSupportedException($"{typeof(TDocument).FullName} doesn't support a MongoCollection (doesn't have the CollectionName attribute)");

            _collection =
                new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_STRING"))
                .GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"))
                .GetCollection<TDocument>(collectionName);
        }
    }
}
