using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public bool IsActive { get; set; } = true;
    }
}
