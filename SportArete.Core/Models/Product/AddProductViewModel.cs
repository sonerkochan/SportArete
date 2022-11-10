using SportArete.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Product
{
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
        //[Range(typeof(decimal), MinPrice, MaxPrice, ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        public string ImageData { get; set; } = null!; //change to byte[]

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public int BrandId { get; set; }
        public IEnumerable<Brand> Brands { get; set; } = new List<Brand>();
    }
}
