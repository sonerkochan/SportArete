using SportArete.Core.Contracts;
using SportArete.Core.Models.Brand;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the brands.
    /// </summary>
    public class BrandService : IBrandService
    {

        private readonly IRepository repo;

        public BrandService(IRepository _repo)
        {
            repo = _repo;
        }

        [Description("Creates a new product and adds it to the database.")]
        public async Task AddBrandAsync(AddBrandViewModel model)
        {
            var entity = new Brand()
            {
                Name = model.Name,
                Description = model.Description
            };

            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
        }
    }
}
