using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Tests
{
    public class ProductServiceTests
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
        public async Task Test_AddProductAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            await productService.AddProductAsync(new AddProductViewModel()
            {
                Model = "added product model",
                Description = "added product description",
                Size = "added product size",
                Colour = "added product colour",
                Price = 100M,
                CategoryId = 1,
                BrandId = 1,
                ImageData = "added product image link"
            });

            await repo.SaveChangesAsync();

            var dbProduct = await repo.GetByIdAsync<Product>(3);

            Assert.That(dbProduct.Description, Is.EqualTo("added product description"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
