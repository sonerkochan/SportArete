using System.ComponentModel;

namespace SportArete.Core.Models.Product
{
    /// <summary>
    /// View model for visualizing products while browsing the app.
    /// </summary>
    /// 
    public class ProductViewModel
    {
        [Description("The Id of the product view model.")]
        public int Id { get; set; }

        [Description("The Model of the product view model.")]
        public string Model { get; set; }

        [Description("The Price of the product view model.")]
        public decimal Price { get; set; }

        [Description("Link to the image of the product.")]
        public string ImageData { get; set; }

        [Description("Name of the category of the product.")]
        public string Category { get; set; }

        [Description("Name of the brand of the product.")]
        public string Brand { get; set; }
    }
}
