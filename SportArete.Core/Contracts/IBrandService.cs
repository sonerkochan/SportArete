using SportArete.Core.Models.Brand;

namespace SportArete.Core.Contracts
{
    public interface IBrandService
    {
        Task AddBrandAsync(AddBrandViewModel model);
    }
}
