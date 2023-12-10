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
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(CreateBrands());
        }

        private List<Brand> CreateBrands()
        {
            List<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                     Id = 1,
                     Name = "Nike",
                     Description = "The world's largest athletic apparel company, Nike is best known for its footwear, " +
                     "apparel, and equipment. Founded in 1964 as Blue Ribbon Sports, the company became Nike in 1971"  +
                     "after the Greek goddess of victory. One of the most valuable brands among sport businesses, Nike " +
                     "employs over 76,000 people worldwide."
                },
                new Brand()
                {
                     Id = 2,
                     Name = "Adidas",
                     Description = "Related keylists. adidas AG (adidas) designs, manufactures and markets athletic and sports " +
                     "lifestyle products. The company's product portfolio includes footwear, apparel and accessories such as bags, " +
                     "sun glasses, fitness equipment, and balls."
                },
                new Brand()
                {
                    Id = 3,
                    Name = "Puma",
                    Description = "Puma SE, branded as Puma, is a German multinational corporation that designs and manufactures " +
                    "athletic and casual footwear, apparel and accessories, which is headquartered in Herzogenaurach, Bavaria, Germany. " +
                    "Puma is the third largest sportswear manufacturer in the world."
                },
                new Brand()
                {
                    Id = 4,
                    Name = "Under Armour",
                    Description = "Under Armour Inc (Under Armour) is a developer, marketer, and distributor of apparel, footwear, and accessories. " +
                    "The company provides products under multiple price levels to cater to diverse customer categories."
                },
                new Brand()
                {
                    Id = 5,
                    Name = "Asics",
                    Description = "ASICS Corp (ASICS) is a sporting goods manufacturer offering sports shoes, sportswear, sports equipment to men, women,  and kids. " +
                    "It also offers accessories, including bags and packs, headwear, socks, and intimate wear. ASICS markets its products under Onitsuka  Tiger, " +
                    "ASICS, ASICS Tiger, and Haglofs brand names."
                }
            };
            return brands;
        }
    }
}