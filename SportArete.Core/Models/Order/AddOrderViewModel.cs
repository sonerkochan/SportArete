using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SportArete.Core.Models.Order
{
    /// <summary>
    /// View model for adding a new order
    /// </summary>
    public class AddOrderViewModel
    {
        [Description("Id of the new order")]
        public int Id { get; set; }

        [Required]
        [StringLength(FullNameMaxLength)]
        [Description("Fullname of the receiver")]
        public string FullName { get; set; }

        [Required]
        [StringLength(PhoneMaxLength)]
        [Description("Phonenumber of the receiver")]
        [RegularExpression("^\\+?[1-9][0-9]{7,14}$",
            ErrorMessage = "Invalid phone number. Please use + and your country code.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        [Description("Address of the reciever.")]
        public string Address { get; set; }

        [Required]
        [StringLength(PostalCodeMaxLength)]
        [Description("Postal code of the address.")]
        public string PostalCode { get; set; }

        [Description("Total price of the ordered products.")]
        public decimal? TotalPrice { get; set; }

        [Description("Date of order.")]
        public DateTime? OrderDate { get; set; }

        [Description("List of product Ids that are in the order.")]
        public List<int> ProductIds { get; set; } = new List<int>();

        [Description("Id of the user that made the order.")]
        public string? UserId { get; set; } = null!;

        [Description("Flag indicating whether the order is complete. Default value is false.")]
        public bool? IsComplete { get; set; } = false;
    }
}
