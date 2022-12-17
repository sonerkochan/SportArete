using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for orders.
    /// </summary>
    public class Order
    {
        [Key]
        [Description("Id of the order.")]
        public int Id { get; set; }

        [Required]
        [StringLength(FullNameMaxLength)]
        [Description("Fullname of the reciever.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(PhoneMaxLength)]
        [Description("Phone number of the reciever.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        [Description("Address of the reciever.")]
        public string Address { get; set; }

        [Required]
        [StringLength(PostalCodeMaxLength)]
        [Description("Postal code of the address.")]
        public string PostalCode { get; set; }

        [Required]
        [Description("Total price of the ordered products.")]
        public decimal TotalPrice { get; set; }

        [Description("Date of order.")]
        public DateTime OrderDate { get; set; }

        [Description("List of products.")]
        public IEnumerable<OrderProduct> ProductIds { get; set; } = new List<OrderProduct>();

        [Description("Id of the user that made the order.")]
        public string UserId { get; set; } = null!;

        [Description("Flag indicating whether the order is complete. Default value is false.")]
        public bool? IsComplete { get; set; } = false;
    }
}
