using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for carts.
    /// </summary>
    public class Cart
    {
        [Key]
        [Description("Id of the cart.")]
        public int Id { get; set; }

        [Description("Id of the user whose cart this is.")]
        public string UserId { get; set; }
        
        [Description("List of products that are in the cart.")]
        public List<CartProduct> ProductIds { get; set; } = new List<CartProduct>();


    }
}
