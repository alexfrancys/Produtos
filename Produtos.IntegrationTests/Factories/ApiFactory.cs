using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Produtos.IntegrationTests.Fixtures;

namespace Produtos.IntegrationTests.Factories
{
    [Collection("Database")]
    public class ApiFactory : WebApplicationFactory<Program>
    {
        private readonly DbFixture _dbFixture;

        public ApiFactory(DbFixture dbfixture)
        {
            _dbFixture = dbfixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Development");
            
            builder.ConfigureServices(services => {
            });

            builder.ConfigureAppConfiguration((context, configuration) => 
            {
                configuration.AddInMemoryCollection(new[] 
                {
                    new KeyValuePair<string, string>("ConnectionStrings:Default", _dbFixture.ConnectionString),

                });
            });
        }
    }
}
