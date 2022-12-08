namespace SportArete.Core.Models.Review
{
    public class AddReviewViewModel
    {
        public int Raiting { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }

        public int ProductId { get; set; }
    }
}
