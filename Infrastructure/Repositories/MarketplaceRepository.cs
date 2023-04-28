using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MarketplaceRepository : IMarketplaceRepository
    {

        private List<MarketplaceEntity> marketplaces = new List<MarketplaceEntity>
        {
            new MarketplaceEntity{ Id = 1, Name= "MarjanMall", Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged" } 
        };

        public MarketplaceEntity GetById(int id)
        {
            return marketplaces.FirstOrDefault(_ => _.Id == id);
        }

        /*public MarketplaceEntity GetAll()
        {
            return marketplaces.ToList();
        }*/
    }
}
