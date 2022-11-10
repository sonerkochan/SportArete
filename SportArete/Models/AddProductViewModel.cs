using SportArete.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Models
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(ProductModelMaxLength, MinimumLength = ProductModelMinLength)]
        public string Model { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        //[Range(typeof(decimal), MinPrice, MaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        public string ImageData { get; set; } //change to byte[]

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int BrandId { get; set; }
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    }
}
