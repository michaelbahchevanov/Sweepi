using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Sweepi.UserServiceAPI.Data;
using Sweepi.UserServiceAPI.Models;

namespace Sweepi.UserServiceAPI.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
              .WithWebHostBuilder(builder =>
              {
                  builder.ConfigureServices(services =>
                  {
                      var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                        typeof(DbContextOptions<UserDbContext>));

                      if (descriptor != null)
                      {
                          services.Remove(descriptor);
                      }
                      services.AddDbContext<UserDbContext>(options =>
                      {
                          options.UseInMemoryDatabase("TestDb");
                      });
                  });
              });
            TestClient = appFactory.CreateClient();
        }
    }
}