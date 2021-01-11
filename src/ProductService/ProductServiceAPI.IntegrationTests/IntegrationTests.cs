using System;
using Xunit;
using Moq;
using Sweepi.ProductServiceAPI.Data;
using Sweepi.ProductServiceAPI.Repository;
using ProductServiceAPI.IntegrationTests.Helpers;
using System.Threading.Tasks;
using Sweepi.ProductServiceAPI.Models;
using System.Linq;
using FluentAssertions;

namespace ProductServiceAPI.IntegrationTests
{
    public class IntegrationTests : IDisposable
    {
        private readonly ProductDbContext db;
        private readonly ProductRepository repo;

        public IntegrationTests()
        {
            db = ContextHelper.GetUniqueInMemory();
            repo = new ProductRepository(db);
        }

        [Fact]
        public async Task Repo()
        {
            var expected = new Product
            {
                Id = Guid.NewGuid().ToString(),
                UserId = "testing1"
            };

            var createdProduct = await repo.Create(expected);

            var actual = db.Products.Single(p => p.Id == expected.Id);

            actual.Should().BeEquivalentTo(expected);

            createdProduct.Should().BeEquivalentTo(expected);
        }
        public void Dispose() => db.Dispose();
    }
}
