using SportArete.Core.Models.Brand;

namespace SportArete.Core.Contracts
{
    /// <summary>
    /// The interface for the BrandService.
    /// </summary>
    public interface IBrandService
    {
        /// <summary>
        /// Creates a brand and adds it to the database
        /// </summary>
        /// <param name="model">A data transfer object for adding a brand.</param>
        /// <returns>Task</returns>
        Task AddBrandAsync(AddBrandViewModel model);
    }
}
