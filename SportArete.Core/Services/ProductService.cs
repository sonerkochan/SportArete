using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Services
{
    public class ProductService : IProductService
    {
        public Task AddProductAsync(AddProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
