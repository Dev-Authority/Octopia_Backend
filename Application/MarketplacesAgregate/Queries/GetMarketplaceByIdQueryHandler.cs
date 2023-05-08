using Application.Marketplaces.Models;
using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplaceByIdQueryHandler : IRequestHandler<GetMarketplaceByIdQuery, Result<MarketplaceEntity>>
    {

        private readonly IMarketplaceRepository _marketplaceRepository;

        public GetMarketplaceByIdQueryHandler(IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }

        public async Task<Result<MarketplaceEntity>> Handle(GetMarketplaceByIdQuery request, CancellationToken cancellationToken)
        {
            //Validation
            if(request.Id == null)
            {
                return Result.Fail($"Identifier < 1");
            }

            //Process
            MarketplaceEntity marketplace = _marketplaceRepository.GetById(request.Id);

            //Success

            return Result.Ok(marketplace);

        }
    }
}
