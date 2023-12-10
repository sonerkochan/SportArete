using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;
using System.Security.Claims;

namespace SportArete.Core.Contracts
{
    /// <summary>
    /// The interface for the CartService.
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Adds a product to the user's cart.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <param name="productId">Product's Id.</param>
        /// <returns>Task</returns>
        Task AddToCartAsync(string userId, int productId);

        /// <summary>
        /// Removes a given product from the user's cart.
        /// </summary>
        /// <param name="userId">/User's Id.</param>
        /// <param name="productId">Product's Id.</param>
        /// <returns>Task</returns>
        Task RemoveFromCartAsync(string userId, int productId);

        /// <summary>
        /// Clears a user's cart after completing an order.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <param name="productIds">List of Ids of the removed products.</param>
        /// <returns>Task</returns>
        Task ClearCartAsync(string userId, List<int> productIds);

        /// <summary>
        /// Creates a cart for a new user.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <returns>Task</returns>
        Task CreateCartForUser(string userId);

        /// <summary>
        /// Get's all products in the user's cart.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <returns>List of products that are in a user's cart.</returns>
        Task<IEnumerable<ProductViewModel>> GetAllAsync(string userId);

        /// <summary>
        /// Checks if there are any products in the user's cart.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <returns>A flag indicating if there is any product or not.</returns>
        bool AnyProducts(string userId);
    }
}
