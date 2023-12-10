using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Product
{
    /// <summary>
    /// View model for adding a new product
    /// </summary>
    public class AddProductViewModel
    {
        [Required]
        [StringLength(ProductModelMaxLength, MinimumLength = ProductModelMinLength)]
        [Description("New Product's Model.")]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Description("New Product's Description.")]
        public string Description { get; set; } = null!;

        [Required]
        [Description("New Product's Size.")]
        public string Size { get; set; } = null!;

        [Required]
        [Description("New Product's Colour.")]
        public string Colour { get; set; } = null!;

        [Required]
        [Description("New Product's Price.")]
        public decimal Price { get; set; }

        [Required]
        [Description("Link to the new product's image.")]
        public string ImageData { get; set; } = null!;

        [Description("Id of the cateogory of the new product.")]
        public int CategoryId { get; set; }

        [Description("List of all available categories.")]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Description("Id of the brand of the new product.")]
        public int BrandId { get; set; }

        [Description("List of all available brands.")]
        public IEnumerable<SportArete.Infrastructure.Data.Models.Brand> Brands { get; set; } = 
            new List<SportArete.Infrastructure.Data.Models.Brand>();
    }
}
