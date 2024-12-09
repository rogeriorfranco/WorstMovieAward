using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using Worst.Movie.Award.Infrastructure.Repository;

namespace Worst.Movie.Award.Tests
{
    internal class CustomWebApplicationFactory: WebApplicationFactory<Program> 
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<MovieAwardContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<MovieAwardContext>(options =>
                {
                    options.UseInMemoryDatabase("MovieList");
                });
            });

            builder.UseEnvironment("Development");
        }
    }
}
