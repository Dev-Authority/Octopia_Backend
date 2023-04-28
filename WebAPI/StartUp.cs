using System;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Injector;


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
