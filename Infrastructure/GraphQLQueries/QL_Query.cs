using Domain.Marketplaces.Entites;
using Domain.Marketplaces.GraphQLQueries;
using Infrastructure.MongoDB.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.GraphQLQueries
{
    public class QL_Query : IQL_Query
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<MarketplaceEntity> _marketplaces = null;
        public QL_Query(IMongoDbSettings settings)
        {
            _mongoClient = new MongoClient(settings.ConnectionString);
            _database = _mongoClient.GetDatabase(settings.DatabaseName);
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
    }
}
