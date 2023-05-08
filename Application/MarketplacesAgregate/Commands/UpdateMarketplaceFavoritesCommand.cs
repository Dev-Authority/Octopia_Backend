using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MarketplacesAgregate.Commands
{
    public class UpdateMarketplaceFavoritesCommand : IRequest<string>
    {
        public string Id { get; set; }
        public bool isFavorite { get; set; }
    }
}
