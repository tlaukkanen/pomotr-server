using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Pomotr.Server.Database;

namespace Pomotr.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = (IWebHost)CreateHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Errands.AddRange(
                  new Errand
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Take out the trash",
                      ValuePoints = 2,
                  },
                  new Errand
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Empty dishwasher",
                      ValuePoints = 3,
                  },
                  new Errand
                  {
                      Id = Guid.NewGuid().ToString(),
                      Name = "Move the lawn",
                      ValuePoints = 5
                  }
                );

                context.SaveChanges();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
