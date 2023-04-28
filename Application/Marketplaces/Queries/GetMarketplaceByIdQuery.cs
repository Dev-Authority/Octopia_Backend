using Application.Marketplaces.Models;
using FluentResults;
using MediatR;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplaceByIdQuery : IRequest<Result<MarketplaceModel>>
    {
        public int Id { get; set; }
    }
}
