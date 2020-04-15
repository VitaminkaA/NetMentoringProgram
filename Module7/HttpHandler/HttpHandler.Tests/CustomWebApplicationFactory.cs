using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HttpHandler.DAL.Context;
using HttpHandler.Tests.Helpers;
using HttpHandler.WebApp;

namespace HttpHandler.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddEntityFrameworkInMemoryDatabase().AddDbContext<NorthwindEFContext>((options) =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                using var scope = services.BuildServiceProvider().CreateScope();

                var db = scope.ServiceProvider.GetRequiredService<NorthwindEFContext>();

                if (db.Database.EnsureCreated())
                    Utilities.InitializeDbForTests(db).Wait(); // Seed the database with test data.
            });
        }
    }
}
