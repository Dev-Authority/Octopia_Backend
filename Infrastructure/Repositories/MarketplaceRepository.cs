using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using Infrastructure.MongoDB.Settings;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MarketplaceRepository : IMarketplaceRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<MarketplaceEntity> _marketplaces = null;
        public MarketplaceRepository(IMongoDbSettings settings) 
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            _database = _mongoClient.GetDatabase(settings.DatabaseName) ;
            _marketplaces = _database.GetCollection<MarketplaceEntity>("Marketplaces");
        }
        

        public MarketplaceEntity GetById(string id)
        {
            return _marketplaces.Find(market => market.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<MarketplaceEntity>> GetAllMarketplacesAsync()
        {
            var Markets = await _marketplaces.FindAsync(p => true);
            return Markets.ToEnumerable(); 
        }

        public async Task<MarketplaceEntity> UpdateMarketplaceFavoritesAsync(string id, bool isFavorite)
        {
            var filter = Builders<MarketplaceEntity>.Filter.Eq(m => m.Id, id);
            var update = Builders<MarketplaceEntity>.Update
                .Set(m => m.isFavorite, isFavorite);

            var options = new FindOneAndUpdateOptions<MarketplaceEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedEntity = await _marketplaces.FindOneAndUpdateAsync(filter, update, options);
            return updatedEntity;
        }

        public async Task<MarketplaceEntity> UpdateMarketplaceStatusAsync(string id, string status)
        {
            var filter = Builders<MarketplaceEntity>.Filter.Eq(m => m.Id, id);
            var update = Builders<MarketplaceEntity>.Update
                .Set(m => m.status, status);

            var options = new FindOneAndUpdateOptions<MarketplaceEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedEntity = await _marketplaces.FindOneAndUpdateAsync(filter, update, options);
            return updatedEntity;
        }
    }
}
