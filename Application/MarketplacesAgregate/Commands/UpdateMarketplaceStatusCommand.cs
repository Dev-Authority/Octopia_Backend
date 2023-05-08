using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MarketplacesAgregate.Commands
{
    public class UpdateMarketplaceStatusCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string status { get; set; }
    }
}
