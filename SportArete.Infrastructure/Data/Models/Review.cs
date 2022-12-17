using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for reviews.
    /// </summary>
    public class Review
    {
        [Key]
        [Description("Id of the review.")]
        public int Id { get; set; }

        [Description("Rating of the review.")]
        public int Rating { get; set; }

        [Description("Comment of the review.")]
        public string Comment { get; set; }

        [Description("Id of the author of the review.")]
        public string UserId { get; set; }

        [Description("Id of the reviewed product.")]
        public int ProductId { get; set; }
    }
}
