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
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id=1,
                    Name="Clothing"
                },
                new Category()
                {
                    Id=2,
                    Name="Shoes"
                },
                new Category()
                {
                    Id=3,
                    Name="Fitness"
                },
                new Category()
                {
                    Id=4,
                    Name="Accessories"
                },
            };
            return categories;
        }
    }
}