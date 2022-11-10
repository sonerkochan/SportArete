using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateProducts());
        }

        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id=1,
                    Model="Air Max 270",
                    Description="The Max Air 270 unit delivers unrivaled, all-day comfort." +
                    " The sleek, running-inspired design roots you to everything Nike. Woven" +
                    " and synthetic fabric on the upper provides a lightweight fit and airy feel. " +
                    "Foam midsole feels soft and comfortable.",
                    Colour="Black",
                    Size="42",
                    Price=349.99M,
                    ImageData="https://s13emagst.akamaized.net/products/39220/39219098/images/res_009d5bccaaaf1df7734ccb96a5ab53ae.jpg?v2",
                    CategoryId=2,
                    BrandId=1
                },
                new Product()
                {
                    Id=2,
                    Model="YeezyBoost",
                    Description="The YEEZY BOOST 350 V2 features an upper composed of re-engineered Primeknit. " +
                    "The post-dyed monofilament side stripe is woven into the upper. Reflective threads are woven" +
                    " into the laces. The midsole utilizes adidas’ innovative BOOST™ technology .",
                    Colour="White",
                    Size="43",
                    Price=299.99M,
                    ImageData="https://sneakernews.com/wp-content/uploads/2021/04/adidas-Yeezy-Boost-350-v2-Light-Photos-2.jpg",
                    CategoryId=2,
                    BrandId=2
                },
            };
            return products;
        }
    }
}