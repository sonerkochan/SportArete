using Microsoft.AspNetCore.Identity;
using SportArete.Core.Contracts;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;

namespace SportArete.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> _userManager)
        {
            userManager = _userManager;
        }

        [Description("Returns object of type User by a given username")]
        public User GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }

        public string GetUserNameById(string userId)
        {
            return userManager.FindByIdAsync(userId).GetAwaiter().GetResult().UserName;
        }
    }
}
