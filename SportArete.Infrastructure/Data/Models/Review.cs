using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int Raiting { get; set; }

        public string Comment { get; set; }
        public string UserId { get; set; }
    }
}
