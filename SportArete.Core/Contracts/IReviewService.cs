using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    public interface IReviewService
    {
        public List<Review> GetProductReviews(int productId);
        Task AddReviewAsync(AddReviewViewModel model);
    }
}