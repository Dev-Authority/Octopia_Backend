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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.GraphQLQueries;
using MongoDB.Driver;

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

            services.Configure<MongoDbSettings>(
                Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<IMongoDbSettings>(sp=>
                    sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
            services.AddSingleton<IMongoClient>(s =>
                    new MongoClient(Configuration.GetValue<string>("MongoDbSettings:ConnectionString")));

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IMarketplaceRepository, MarketplaceRepository>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("corsPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:3010")
            //                                .AllowAnyHeader()
            //                                .AllowAnyMethod();
            //        });
            //});

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //        {
            //            options.Authority = "https://localhost:7111"; 
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateAudience = false, 
            //                ValidateIssuer = true, 
            //                ValidateIssuerSigningKey = true, 
            //                ValidIssuer = "https://localhost:7111", 
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0FFA06DD318FB46565DB729A60A3154D")) 
            //            };
            //        });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:7111";
                options.Audience = "https://localhost:7192";

            });
            services.AddAuthorization();

            services.AddGraphQLServer()
                    .AddQueryType<QL_Query>();


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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
