using System.ComponentModel;

namespace SportArete.Core.Models.Review
{
    /// <summary>
    /// View model for visualizing a review.
    /// </summary>
    public class ReviewViewModel
    {
        [Description("Review's Id.")]
        public int Id { get; set; }

        [Description("Review's Rating.")]
        public int Rating { get; set; }

        [Description("Review's Conment.")]
        public string Comment { get; set; }

        [Description("The Id of the author of the review.")]
        public string UserId { get; set; }

        [Description("The Username of the author of the review.")]
        public string UserName { get; set; }

        [Description("The Id of the reviewed product.")]
        public int ProductId { get; set; }
    }
}
