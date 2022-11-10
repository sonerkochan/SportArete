using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
