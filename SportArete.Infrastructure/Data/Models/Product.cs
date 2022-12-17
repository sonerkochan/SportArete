using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;
using System.ComponentModel;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for products.
    /// </summary>
    public class Product
    {
        [Key]
        [Description("Id of the product")]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductModelMaxLength)]
        [Description("Model of the product")]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        [Description("Description of the product")]
        public string Description { get; set; } = null!;

        [Required]
        [Description("Colour of the product")]
        public string Colour { get; set; } = null!;

        [Required]
        [Description("Size of the product")]
        public string Size { get; set; } = null!;

        [Required]
        [Description("Price of the product")]
        public decimal Price { get; set; }

        [Required]
        [Description("Link to the image of the product.")]
        public string ImageData { get; set; } = null!;

        [Required]
        [Description("Amount of how many times the product was viewed.")]
        public int ViewsCount { get; set; } = 0;

        [Description("Id of the category of the product.")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]

        public Category Category { get; set; } = null!;

        [Description("Id of the brand of the product.")]
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        [Description("Flag indicating whether the product is still available.")]
        public bool IsAvailable { get; set; } = true;


    }
}
