using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for brands.
    /// </summary>
    public class Brand
    {
        [Key]
        [Description("Id of the brand.")]
        public int Id { get; set; }

        [Required]
        [StringLength(BrandNameMaxLength)]
        [Description("Name of the brand.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Description("Description of the brand.")]
        public string Description { get; set; } = null!;

        [Description("List of the products of that brand.")]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
