using Application.Marketplaces.Models;
using Domain.Marketplaces.Entites;
using Domain.Marketplaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplaceByIdQueryHandler : IRequestHandler<GetMarketplaceByIdQuery, Result<MarketplaceModel>>
    {

        private readonly IMarketplaceRepository _marketplaceRepository;

        public GetMarketplaceByIdQueryHandler(IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }

        public async Task<Result<MarketplaceModel>> Handle(GetMarketplaceByIdQuery request, CancellationToken cancellationToken)
        {
            //Validation
            if(request.Id < 1)
            {
                return Result.Fail($"Identifier < 1");
            }

            //Process
            MarketplaceEntity marketplace = _marketplaceRepository.GetById(request.Id);

            var result = new MarketplaceModel
            {
                Name = marketplace.Name,
                Description = marketplace.Description,
            };

            //Success

            return Result.Ok(result);

        }
    }
}
