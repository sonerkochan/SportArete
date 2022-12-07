using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Brand
{
    /// <summary>
    /// View model for adding a new brand
    /// </summary>
    public class AddBrandViewModel
    {
        [Required]
        [StringLength(BrandNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
