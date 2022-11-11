using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddProductAsync(AddProductViewModel model)
        {
            var entity = new Product()
            {
                Model = model.Model,
                Description = model.Description,
                Size = model.Size,
                Colour = model.Colour,
                Price = model.Price,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                ImageData = model.ImageData
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await repo.All<Brand>().ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.All<Category>().ToListAsync();
        }
    }
}
