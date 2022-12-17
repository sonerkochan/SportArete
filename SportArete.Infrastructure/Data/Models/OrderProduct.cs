using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for a product in an order.
    /// </summary>
    public class OrderProduct
    {
        [Required]
        [Description("Id of the order.")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Required]
        [Description("Id of the product.")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [Description("Price of the product.")]
        public decimal Price { get; set; }
    }
}
