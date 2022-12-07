using SportArete.Infrastructure.Data.Models;
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
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Size { get; set; } = null!;

        [Required]
        public string Colour { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageData { get; set; } = null!; //change to byte[] later

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int BrandId { get; set; }
        public IEnumerable<SportArete.Infrastructure.Data.Models.Brand> Brands { get; set; } = 
            new List<SportArete.Infrastructure.Data.Models.Brand>();
    }
}
