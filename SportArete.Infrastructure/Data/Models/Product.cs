using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Colour { get; set; } = null!;

        [Required]
        public string Size { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageData { get; set; } = null!;

        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]

        public Category Category { get; set; } = null!;

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = null!;

        public bool IsAvailable { get; set; } = true;


    }
}
