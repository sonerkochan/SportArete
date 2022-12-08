using Microsoft.EntityFrameworkCore;
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
    public class ReviewService
    {

        private readonly IRepository repo;

        public ReviewService(IRepository _repo)
        {
            repo = _repo;
        }

        [Description("Creates a new review and adds it to the database.")]
        public async Task AddReviewAsync(AddReviewViewModel model)
        {
            var entity = new Review()
            {
                Raiting = model.Raiting,
                Comment = model.Comment,
                UserId = model.UserId
            };


            await repo.AddAsync(entity);

            ProductReview productReview = new ProductReview()
            {
                ProductId = model.ProductId,
                ReviewId = entity.Id
            };

            int reviewId = repo.All<Review>().OrderByDescending(x => x.Id).FirstOrDefault().Id;

            await repo.AddAsync(productReview);

            await repo.SaveChangesAsync();
        }

        [Description("Returns all reviews of a current product.")]
        public async Task<IEnumerable<ReviewViewModel>> GetAllAsync(int productId)
        {
            return await repo.AllReadonly<Review>()
                .Select(r => new ReviewViewModel()
                {
                    Id = r.Id,
                    Raiting = r.Raiting,
                    Comment = r.Comment,
                    UserId = r.UserId
                })
                .ToListAsync();
        }
    }
}