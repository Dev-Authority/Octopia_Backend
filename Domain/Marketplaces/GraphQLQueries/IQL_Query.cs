using Domain.Marketplaces.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Marketplaces.GraphQLQueries
{
    public interface IQL_Query
    {
        MarketplaceEntity GetById(string id);

        Task<IEnumerable<MarketplaceEntity>> GetAllMarketplacesAsync();
    }
}
