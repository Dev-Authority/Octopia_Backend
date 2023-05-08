using Application.Marketplaces.Models;
using Domain.Marketplaces.Entites;
using FluentResults;
using MediatR;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplaceByIdQuery : IRequest<Result<MarketplaceEntity>>
    {
        public string Id { get; set; }
    }
}
