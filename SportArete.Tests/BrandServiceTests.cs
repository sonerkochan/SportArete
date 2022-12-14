using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Brand;
using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Tests
{
    public class BrandServiceTests
    {
        private IRepository repo;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SportAreteMemoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task Test_AddBrandAsync()
        {
            var repo = new Repository(context);

            IBrandService brandService = new BrandService(repo);
            IProductService productService = new ProductService(repo);

            var model = new AddBrandViewModel()
            {
                Description = "Optimum Nutrition, description.",
                Name = "Optimum Nutrition",
            };

            brandService.AddBrandAsync(model);

            var brands = await productService.GetBrandsAsync();
            var lastAddedBrand = brands.LastOrDefault();

            Assert.That(brands.Count(), Is.EqualTo(6));
            Assert.That(lastAddedBrand.Description, Is.EqualTo("Optimum Nutrition, description."));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
