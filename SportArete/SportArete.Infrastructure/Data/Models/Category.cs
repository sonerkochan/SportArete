using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static SportArete.Infrastructure.Data.Constants.GlobalConstants;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Database model for categories.
    /// </summary>
    public class Category
    {
        [Key]
        [Description("Id of the category.")]
        public int Id { get; set; }

        [StringLength(CategoryNameMaxLength)]
        [Required]
        [Description("Name of the category.")]
        public string Name { get; set; } = null!;

        [Description("List of the products in the category.")]
        public ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
