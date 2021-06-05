using los_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Models
{
    public static class DBInitialize
    {
        public static void INIT(IServiceProvider serviceProvider)
        {
            var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>());

            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(dummyProduct());
            context.SaveChanges();

            context.Stocks.AddRange(dummyStock());
            context.SaveChanges();
        }

        public static IEnumerable<Product> dummyProduct()
        {
            return new List<Product>
            {
                new Product{
                    id = 1,
                    name = "Sofa",
                    imageUrl = "xxxxx",
                    price = 12000
                },
                new Product
                {
                    id=2,
                    name="Table",
                    imageUrl = "xxxxxx",
                    price = 8000
                }
            };
        }
        public static IEnumerable<Stock> dummyStock()
        {
            return new List<Stock>
            {
                new Stock{
                    id = 1,
                    productId =1,
                    amount = 55,
                },
                new Stock
                {
                    id = 2,
                    productId =2,
                    amount = 101,
                }
            };
        }
    }
}
