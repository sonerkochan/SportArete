using SportArete.Core.Models.Product;
using SportArete.Core.Models.Review;

namespace SportArete.Core.Contracts
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewViewModel>> GetAllAsync(int productId);
        Task AddReviewAsync(AddReviewViewModel model);
    }
}