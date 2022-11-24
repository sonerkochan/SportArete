using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
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

        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderProduct> ProductIds { get; set; } = new List<OrderProduct>();
        public string UserId { get; set; } = null!;

        public bool IsComplete { get; set; } = false;
    }
}
