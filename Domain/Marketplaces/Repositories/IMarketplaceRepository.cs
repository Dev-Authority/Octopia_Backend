using System;
using Domain.Marketplaces.Entites;

namespace Domain.Marketplaces.Repositories
{
    public interface IMarketplaceRepository
    {

        MarketplaceEntity GetById(string id);

        Task<IEnumerable<MarketplaceEntity>> GetAllMarketplacesAsync();

        Task<MarketplaceEntity> UpdateMarketplaceFavoritesAsync(string id, bool isFavorite);

        Task<MarketplaceEntity> UpdateMarketplaceStatusAsync(string id, string status);
    }
}
