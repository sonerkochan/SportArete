using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Review
{
    public class AddReviewViewModel
    {
        [Required]
        [Range(typeof(int),"0","5")]
        public int Rating { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
    }
}
