using SportArete.Core.Models.Product;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    /// <summary>
    /// The interface for the ProductService    .
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task AddProductAsync(AddProductViewModel model);

        Task<IEnumerable<ProductViewModel>> GetTopAsync();
        Task<IEnumerable<ProductViewModel>> GetAllAsync();

        Task<IEnumerable<ProductViewModel>> GetAllByBrandAsync(int brandId);
        Task<IEnumerable<ProductViewModel>> GetAllByCategoryAsync(int categoryId);
        Task<Product> GetDetailedProductAsync(int productId);
        Task RemoveProductAsync(int id);
    }
}
