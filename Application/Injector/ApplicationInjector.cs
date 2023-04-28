using Domain.Marketplaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Injector
{
    public static class ApplicationInjector
    {
        public static IServiceCollection AddApplicationInjector(this IServiceCollection services)
        {
            services.AddTransient<IMarketplaceRepository, MarketplaceRepository>();

            return services;
        }
    }
}
