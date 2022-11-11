using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public Cart Cart { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public bool IsComplete { get; set; } = false;
    }
}
