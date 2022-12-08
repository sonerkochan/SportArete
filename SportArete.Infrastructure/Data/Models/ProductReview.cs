using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportArete.Infrastructure.Data.Models
{
    public class ProductReview
    {
        [Required]
        public int ReviewId { get; set; }

        [ForeignKey(nameof(ReviewId))]
        public Review Review { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
    }
}
