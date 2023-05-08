using Application.Marketplaces.Models;
using Domain.Marketplaces.Entites;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Marketplaces.Queries
{
    public class GetMarketplacesQuery : IRequest<IEnumerable<MarketplaceEntity>>
    {
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
    }
}
