using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportArete.Infrastructure.Data.Models
{
    /// <summary>
    /// Extended user model for the database.
    /// </summary>
    public class User : IdentityUser
    {
        [Description("Flag indicating whether the user profile is still active")]
        public bool IsActive { get; set; } = true;
    }
}
