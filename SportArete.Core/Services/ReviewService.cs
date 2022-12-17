using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the reviews.
    /// </summary>
    public class ReviewService:IReviewService
    {

        private readonly IRepository repo;
        private readonly ApplicationDbContext context;

        public ReviewService(IRepository _repo,
            ApplicationDbContext _context)
        {
            repo = _repo;
            context = _context;
        }

        [Description("Creates a new review and adds it to the database.")]
        public async Task AddReviewAsync(AddReviewViewModel model)
        {
            var entity = new Review()
            {
                Rating = model.Rating,
                Comment = model.Comment,
                UserId = model.UserId,
                ProductId = model.ProductId
            };


            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        [Description("Returns all reviews of a current product.")]
        public List<Review> GetProductReviews(int productId)
        {
            var reviews = repo.All<Review>().Where(r => r.ProductId == productId).ToList();

            return reviews;
        }
    }
}