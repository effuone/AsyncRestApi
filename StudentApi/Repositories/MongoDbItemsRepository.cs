using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using StudentApi.Models;

namespace StudentApi.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository<Item>
    {
        private const string databaseName = "StudentCouncil";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public MongoDbItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public async Task CreateAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item=>item.Id, id);
            await itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            var filter = filterBuilder.Eq(existingItem=>existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter,item);
        }
    }
}