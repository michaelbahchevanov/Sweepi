using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sweepi.ProductServiceAPI.Models;
using Sweepi.ProductServiceAPI.Data;

namespace ProductServiceAPI.IntegrationTests.Helpers
{
    static class ContextHelper
    {
        public static ProductDbContext GetUniqueInMemory()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
               .UseInMemoryDatabase($"Testing-{Guid.NewGuid()}")
               .Options;

            var db = new ProductDbContext(options);

            db.RemoveRange(db.Products);

            db.AddRange(new[]
            {
                new Product { Id = Guid.NewGuid().ToString(), Category = "testing", Favourite = false, Name = "test", UserId = "test-user" },
                new Product { Id = Guid.NewGuid().ToString(), Category = "testing1", Favourite = false, Name = "test2", UserId = "test-user2" },
                new Product { Id = Guid.NewGuid().ToString(), Category = "testing2", Favourite = false, Name = "test3", UserId = "test-user3" },
                new Product { Id = Guid.NewGuid().ToString(), Category = "testing3", Favourite = false, Name = "test4", UserId = "test-user4" },
                new Product { Id = Guid.NewGuid().ToString(), Category = "testing4", Favourite = false, Name = "test5", UserId = "test-user5" }
            });

            db.SaveChanges();

            return db;
        }
    }
}
