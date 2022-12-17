using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Review
{
    /// <summary>
    /// View model for adding a new review.
    /// </summary>
    public class AddReviewViewModel
    {
        [Required]
        [Range(typeof(int),"0","5")]
        [Description("Rating of the reviewed product.")]
        public int Rating { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        [Description("Comment for the reviewed product.")]
        public string Comment { get; set; }

        [Description("The Id of the author of the review.")]
        public string UserId { get; set; }

        [Description("The Id of the reviewed product.")]
        public int ProductId { get; set; }
    }
}
