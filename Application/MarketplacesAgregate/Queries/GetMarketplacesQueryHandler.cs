using Application.Marketplaces.Models;
using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using FluentResults;
using Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplacesQueryHandler : IRequestHandler<GetMarketplacesQuery, IEnumerable<MarketplaceEntity>>
    {
        private readonly IMarketplaceRepository _marketplaceRepository;

        public GetMarketplacesQueryHandler(IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }

        public async Task<IEnumerable<MarketplaceEntity>> Handle(GetMarketplacesQuery request, CancellationToken cancellationToken)
        {
            return  await _marketplaceRepository.GetAllMarketplacesAsync();
        }
    }
}
