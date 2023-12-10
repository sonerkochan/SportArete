using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Tests
{
    public class CartServiceTests
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

        // Id = "dea12856-c198-4129-b3f3-b893d8395082",
        //   Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",

        [Test]
        public async Task Test_CreateCartForUser()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            Assert.That(cartsCount, Is.EqualTo(0));

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            cartsCount = repo.All<Cart>().Count();

            Assert.That(cartsCount, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_AddToCartAsync()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            cartService.AddToCartAsync(userId, 1);
            cartService.AddToCartAsync(userId, 2);

            int cpCount = repo.All<CartProduct>().Count();

            Assert.That(cpCount, Is.EqualTo(2));
        }

        [Test]
        public async Task Test_GetAllAsync()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            cartService.AddToCartAsync(userId, 1);
            cartService.AddToCartAsync(userId, 2);

            var cartProducts = await cartService.GetAllAsync(userId);

            var cartProductOne = cartProducts.FirstOrDefault();

            Assert.That(cartProducts.Count(), Is.EqualTo(2));
            Assert.That(cartProductOne.Model, Is.EqualTo("Air Max 270"));
        }

        [Test]
        public async Task Test_RemoveFromCartAsync()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            cartService.AddToCartAsync(userId, 1);
            cartService.AddToCartAsync(userId, 2);

            int cpCount = repo.All<CartProduct>().Count();

            Assert.That(cpCount, Is.EqualTo(2));

            cartService.RemoveFromCartAsync(userId, 1);

            cpCount = repo.All<CartProduct>().Count();

            Assert.That(cpCount, Is.EqualTo(1));
        }

        [Test]
        public async Task Test_ClearCartAsync()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            cartService.AddToCartAsync(userId, 1);
            cartService.AddToCartAsync(userId, 2);

            int cpCount = repo.All<CartProduct>().Count();

            Assert.That(cpCount, Is.EqualTo(2));

            List<int> productIds = new List<int>()
            {
                1,
                2
            };

            cartService.ClearCartAsync(userId, productIds);

            cpCount = repo.All<CartProduct>().Count();

            Assert.That(cpCount, Is.EqualTo(0));
        }

        [Test]
        public void Test_AnyProducts()
        {
            var repo = new Repository(context);

            ICartService cartService = new CartService(context, repo);

            int cartsCount = repo.All<Cart>().Count();

            string userId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e";

            cartService.CreateCartForUser(userId);

            Assert.That(cartService.AnyProducts(userId), Is.False);

            cartService.AddToCartAsync(userId, 1);
            cartService.AddToCartAsync(userId, 2);

            Assert.That(cartService.AnyProducts(userId), Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}