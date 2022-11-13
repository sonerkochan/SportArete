namespace SportArete.Core.Models.Product
{
    public class DetailedProductViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string ImageData { get; set; } //change to byte[]

        public string Category { get; set; }

        public string Brand { get; set; }
    }
}
