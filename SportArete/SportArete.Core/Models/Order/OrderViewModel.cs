using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Core.Models.Order
{
    /// <summary>
    /// View model of an order.
    /// </summary>
    public class OrderViewModel
    {
        [Description("Id of the new order")]
        public int Id { get; set; }

        [Description("Fullname of the receiver")]
        public string FullName { get; set; }

        [Description("Phonenumber of the receiver")]
        public string Phone { get; set; }

        [Description("Address of the reciever.")]
        public string Address { get; set; }

        [Description("Postal code of the address.")]
        public string PostalCode { get; set; }

        [Description("Total price of the ordered products.")]
        public decimal? TotalPrice { get; set; }

        [Description("Date of order.")]
        public DateTime OrderDate { get; set; }

        [Description("List of product Ids that are in the order.")]
        public List<int> ProductIds { get; set; } = new List<int>();

        [Description("Id of the user that made the order.")]
        public string? UserId { get; set; }

        [Description("Flag indicating whether the order is complete. Default value is false.")]
        public bool? IsComplete { get; set; }
    }
}
