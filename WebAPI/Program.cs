
using Microsoft.AspNetCore;
using WebApi;

namespace WebAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildHost(args).Build().Run();
        }

        public static IWebHostBuilder BuildHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<StartUp>();
        }
    }
}