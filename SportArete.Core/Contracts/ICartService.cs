using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCartAsync(string userId, int productId);
        Task RemoveFromCartAsync(string userId, int productId);
        Task ClearCartAsync(string userId, List<int> productIds);

        Task CreateCartForUser(string userId);
        Task<IEnumerable<ProductViewModel>> GetAllAsync(string userId);
        bool AnyProducts(string userId);
    }
}
