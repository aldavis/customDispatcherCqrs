using System.Data.Entity.Migrations;
using System.Linq;
using domain.Model;

namespace application.Infrastructure.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(application.Infrastructure.Persistence.EntityFrameworkContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    CurrentInventoryCount = 3,
                    Description = "Test Product One",
                    InventoryReorderThreshold = 2,
                    OnOrderCount = 4,
                    PartNumber = "TP1",
                    Price = 125.25m
                });

                context.Products.Add(new Product
                {
                    CurrentInventoryCount = 3,
                    Description = "Test Product Two",
                    InventoryReorderThreshold = 2,
                    OnOrderCount = 4,
                    PartNumber = "TP2",
                    Price = 25.25m
                });

                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer {Name = "Test Customer One",AllowedDiscountAmount = 10.5m});
                context.Customers.Add(new Customer { Name = "Test Customer Two", AllowedDiscountAmount = 5 });

                context.SaveChanges();
            }
        }
    }
}
