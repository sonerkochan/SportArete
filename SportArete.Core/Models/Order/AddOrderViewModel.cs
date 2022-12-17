using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Models.Order
{
    /// <summary>
    /// View model for adding a new order
    /// </summary>
    public class AddOrderViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [StringLength(PhoneMaxLength)]
        public string Phone { get; set; }

        [Required]
        [StringLength(AddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [StringLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? OrderDate { get; set; }

        public List<int> ProductIds { get; set; } = new List<int>();
        public string? UserId { get; set; } = null!;

        public bool IsComplete { get; set; } = false;
    }
}
