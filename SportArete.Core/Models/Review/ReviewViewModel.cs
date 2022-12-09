namespace SportArete.Core.Models.Review
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
    }
}
