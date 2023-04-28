using System;
using Domain.Marketplaces.Entites;

namespace Domain.Marketplaces.Repositories
{
    public interface IMarketplaceRepository
    {

        MarketplaceEntity GetById(int id);
        //MarketplaceEntity GetAll();
    }
}
