using SportArete.Core.Models.Order;
using SportArete.Core.Models.Product;
using SportArete.Core.Models.User;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Contracts
{
    /// <summary>
    /// The interface for the OrderService.
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Creates an order for the user.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <returns>Task</returns>
        Task CreateOrderForUser(string userId);

        /// <summary>
        /// Gets all Ids of the products in the user's cart.
        /// </summary>
        /// <param name="userId">User's Id.</param>
        /// <returns>List of Ids.</returns>
        List<int> GetAllProductIds(string userId);

        /// <summary>
        /// Creates a new order for a given user.
        /// </summary>
        /// <param name="model">Data transfer object for adding an order.</param>
        /// <param name="userId">User's Id.</param>
        /// <returns>Task</returns>
        Task AddOrderAsync(AddOrderViewModel model, string userId);

        Task<IEnumerable<OrderViewModel>> All();

        Task<IEnumerable<OrderViewModel>> Mine(string userId);

    }
}
