using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(CategoryNameMaxLength)]
        [Required]
        public string Name { get; set; } = null!;

        public IEnumerable<Product> Products { get; set; }=new List<Product>();
    }
}
