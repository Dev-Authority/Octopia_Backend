using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Injector;
using Infrastructure.Repositories;
using Domain.Marketplaces.Repositories;
using Infrastructure.MongoDB.Settings;
using Microsoft.Extensions.Options;
using Application.Marketplaces.Queries;
using Domain.Marketplaces.Entites;

namespace WebApi
{
    public class StartUp
    {

        public IConfiguration Configuration { get; }

        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // DI
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IMarketplaceRepository, MarketplaceRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy("corsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3010")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });


            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddMvc();

            services.AddApplicationInjector();

        }


        // middleware
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
