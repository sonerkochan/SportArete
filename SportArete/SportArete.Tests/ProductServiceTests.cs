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

        [Test]
        public async Task Test_GetTopAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var dbProducts = await productService.GetTopAsync();

            Assert.That(dbProducts.Count(),Is.EqualTo(2));
        }

        [Test]
        public async Task Test_GetAllAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var dbProducts = await productService.GetAllAsync();

            Assert.That(dbProducts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Test_GetBrandsAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var dbBrands = await productService.GetBrandsAsync();

            var brand = dbBrands.Where(x => x.Id == 1).FirstOrDefault();

            Assert.That(dbBrands.Count(), Is.EqualTo(5));
            Assert.That(brand.Name == "Nike");
        }


        [Test]
        public async Task Test_GetCategoriesAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var dbCategories = await productService.GetCategoriesAsync();

            var category = dbCategories.Where(x => x.Id == 1).FirstOrDefault();

            Assert.That(dbCategories.Count(), Is.EqualTo(4));
            Assert.That(category.Name == "Clothing");
        }

        [Test]
        public async Task Test_GetDetailedProductAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var detailedProduct = await productService.GetDetailedProductAsync(1);

            Assert.That(detailedProduct.Model, Is.EqualTo("Air Max 270"));
        }

        [Test]
        public async Task Test_GetAllByBrandAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var brandProducts = await productService.GetAllByBrandAsync(1);

            Assert.That(brandProducts.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task Test_GetAllByCategoryAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            var categoryProducts = await productService.GetAllByCategoryAsync(2);

            Assert.That(categoryProducts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task Test_RemoveProductAsync()
        {
            var repo = new Repository(context);

            IProductService productService = new ProductService(repo);

            await productService.RemoveProductAsync(1);

            var product = await repo.GetByIdAsync<Product>(1);

            Assert.That(product.IsAvailable, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
