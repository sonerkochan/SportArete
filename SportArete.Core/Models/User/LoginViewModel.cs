using System.ComponentModel.DataAnnotations;

namespace SportArete.Core.Models.User
{
    /// <summary>
    /// View model to pass data while logging in.
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
