using SportArete.Core.Models.Order;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderForUser(string userId);
        List<int> GetAllProductIds(string userId);
        Task AddOrderAsync(AddOrderViewModel model, string userId);

    }
}
