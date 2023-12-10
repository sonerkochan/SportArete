using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    /// <summary>
    /// The interface for the ReviewService.
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Gets all reviews of a given product.
        /// </summary>
        /// <param name="productId">Product's Id.</param>
        /// <returns>List of reviews</returns>
        public List<Review> GetProductReviews(int productId);

        /// <summary>
        /// Adds a new review to a product.
        /// </summary>
        /// <param name="model">Data transfer object for adding a review.</param>
        /// <returns>Task</returns>
        Task AddReviewAsync(AddReviewViewModel model);
    }
}