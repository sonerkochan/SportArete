using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;
using System.Net;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            repo = _repo;
        }

        [Description("Creates a new product and adds it to the database.")]
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

        [Description("Returns the top 3 products(Most viewed 3 products).")]
        public async Task<IEnumerable<ProductViewModel>> GetTopAsync()
        {
            return await repo.AllReadonly<Product>()
                .OrderByDescending(h => h.ViewsCount)
                .Select(h => new ProductViewModel()
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

        [Description("Returns all brands as a list.")]
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await repo.All<Brand>().ToListAsync();
        }

        [Description("Returns all categories as a list.")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await repo.All<Category>().ToListAsync();
        }

        [Description("Returns a selected product.")]
        public async Task<Product> GetDetailedProductAsync(int productId)
        {
            return await repo.GetByIdAsync<Product>(productId);
        }

        [Description("Returns all product.")]
        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return await repo.AllReadonly<Product>()
                .OrderByDescending(h => h.ViewsCount)
                .Where(h => h.IsAvailable == true)
                .Select(h => new ProductViewModel()
                {
                    Id = h.Id,
                    Model = h.Model,
                    Price = h.Price,
                    ImageData = h.ImageData,
                    Category = h.Category.Name,
                    Brand = h.Brand.Name
                })
                .OrderBy(p=>p.Category)
                .ToListAsync();
        }

        [Description("Returns products that are from a given brand.")]
        public async Task<IEnumerable<ProductViewModel>> GetAllByBrandAsync(int brandId)
        {
            return await repo.AllReadonly<Product>()
                .OrderByDescending(h => h.ViewsCount)
                .Where(p => p.BrandId == brandId)
                .Select(h => new ProductViewModel()
                {
                    Id = h.Id,
                    Model = h.Model,
                    Price = h.Price,
                    ImageData = h.ImageData,
                    Category = h.Category.Name,
                    Brand = h.Brand.Name
                })
                .OrderBy(p => p.Category)
                .ToListAsync();
        }

        [Description("Returns products that are from a given Category.")]
        public async Task<IEnumerable<ProductViewModel>> GetAllByCategoryAsync(int categoryId)
        {
            return await repo.AllReadonly<Product>()
                .OrderByDescending(h => h.ViewsCount)
                .Where(p => p.CategoryId == categoryId)
                .Select(h => new ProductViewModel()
                {
                    Id = h.Id,
                    Model = h.Model,
                    Price = h.Price,
                    ImageData = h.ImageData,
                    Category = h.Category.Name,
                    Brand = h.Brand.Name
                })
                .OrderBy(p=>p.Category)
                .ToListAsync();
        }

        public async Task RemoveProductAsync(int id)
        {
            var product = await repo.GetByIdAsync<Product>(id);
            product.IsAvailable = false;

            await repo.SaveChangesAsync();

        }
    }
}
