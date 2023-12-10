using SportArete.Core.Models.Review;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;

namespace SportArete.Core.Models.Product
{
    /// <summary>
    /// View model for visualizing a selected product
    /// </summary>
    public class DetailedProductViewModel
    {
        [Description("The Id of the product view model.")]
        public int Id { get; set; }

        [Description("The Model of the product view model.")]
        public string Model { get; set; }

        [Description("The Description of the product view model.")]
        public string Description { get; set; }

        [Description("The Size of the product view model.")]
        public string Size { get; set; }


        [Description("The Price of the product view model.")]
        public decimal Price { get; set; }

        [Description("Link to the image of the product.")]
        public string ImageData { get; set; }

        [Description("Name of the category of the product.")]
        public string Category { get; set; }

        [Description("Name of the brand of the product.")]
        public string Brand { get; set; }

        [Description("List of reviews of the product.")]
        public ICollection<ReviewViewModel> Reviews { get; set; } = new List<ReviewViewModel>();
    }
}
