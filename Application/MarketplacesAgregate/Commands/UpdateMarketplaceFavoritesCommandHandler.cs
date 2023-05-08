using Domain.Marketplaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection.Metadata;
using FluentResults;

namespace Application.MarketplacesAgregate.Commands
{
    public class UpdateMarketplaceFavoritesCommandHandler : IRequestHandler<UpdateMarketplaceFavoritesCommand, string>
    {
        private readonly IMarketplaceRepository _marketplaceRepository;

        public UpdateMarketplaceFavoritesCommandHandler (IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }
        
        public async Task<string> Handle(UpdateMarketplaceFavoritesCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return "param is null";
            }
            else
            {
                var Id = command.Id;
                var isFavorite = command.isFavorite;
                if (_marketplaceRepository.GetById(Id)!= null)
                {
                    var result = await _marketplaceRepository.UpdateMarketplaceFavoritesAsync(Id, isFavorite);
                    return "Updated Successfully";
                }
                else
                {
                    return "Object Not Found";
                }
            }

            //var Id = command.Id;
            //var isFavorite = command.isFavorite;
            //var status = command.status;

            //return await _marketplaceRepository.UpdateMarketplaceAsync(Id, isFavorite, status);

            //return result;

        }
    }
}
