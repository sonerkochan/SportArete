using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {

        public int? CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart? Cart { get; set; } = null!;

    }
}
