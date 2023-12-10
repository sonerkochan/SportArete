using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Core.Services;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Tests
{
    public class ReviewServiceTests
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
        public async Task Test_AddReviewAsync()
        {
            var repo = new Repository(context);

            IReviewService reviewService = new ReviewService(repo, context);

            var model = new AddReviewViewModel()
            {
                Comment = "Nice Shoes",
                ProductId = 1,
                Rating = 5,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            reviewService.AddReviewAsync(model);

            var model2 = new AddReviewViewModel()
            {
                Comment = "Good for the price!",
                ProductId = 2,
                Rating = 4,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };
            reviewService.AddReviewAsync(model2);

            int reviewsCount = repo.All<Review>().Count();

            Assert.That(reviewsCount, Is.EqualTo(2));
        }

        [Test]
        public void Test_GetProductReviews()
        {
            var repo = new Repository(context);

            IReviewService reviewService = new ReviewService(repo, context);

            var model = new AddReviewViewModel()
            {
                Comment = "Nice Shoes",
                ProductId = 1,
                Rating = 5,
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            reviewService.AddReviewAsync(model);

            var model2 = new AddReviewViewModel()
            {
                Comment = "Good for the price!",
                ProductId = 1,
                Rating = 4,
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            };
            reviewService.AddReviewAsync(model2);

            var reviews = reviewService.GetProductReviews(1);

            var review1 = reviews.FirstOrDefault();

            Assert.That(reviews.Count(), Is.EqualTo(2));
            Assert.That(review1.Comment, Is.EqualTo("Nice Shoes"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
