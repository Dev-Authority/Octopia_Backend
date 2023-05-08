using Domain.Marketplaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MarketplacesAgregate.Commands
{
    public class UpdateMarketplaceStatusCommandHandler : IRequestHandler<UpdateMarketplaceStatusCommand, string>
    {
        readonly IMarketplaceRepository _marketplaceRepository;

        public UpdateMarketplaceStatusCommandHandler(IMarketplaceRepository marketplaceRepository)
        {
            _marketplaceRepository = marketplaceRepository;
        }

        public async Task<string> Handle(UpdateMarketplaceStatusCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return "param is null";
            }
            else
            {
                var Id = command.Id;
                var status = command.status;
                if (_marketplaceRepository.GetById(Id) != null)
                {
                    var result = await _marketplaceRepository.UpdateMarketplaceStatusAsync(Id, status);
                    return "Updated Successfully";
                }
                else
                {
                    return "Object Not Found";
                }
            }


        }
    }
}
