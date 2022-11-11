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
        public async Task<IEnumerable<TopProductViewModel>> GetTopAsync()
        {
            return await repo.AllReadonly<Product>()
                .OrderByDescending(h => h.ViewsCount)
                .Select(h => new TopProductViewModel()
                {
                    Id = h.Id,
                    Model = h.Model,
                    Price = h.Price,
                    ImageData = h.ImageData,
                    Category = h.Category.Name,
                    Brand = h.Brand.Name
                })
                .Take(3)
                .ToListAsync();
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
