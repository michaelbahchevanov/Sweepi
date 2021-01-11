using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sweepi.ProductServiceAPI.Data;


namespace Sweepi.ProductServiceAPI.Config
{
    public static class ApplicationBuilderExtensions
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<ProductDbContext>().Database.Migrate();
        }
    }
}
