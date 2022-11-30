using Microsoft.AspNetCore.Identity;
using SportArete.Core.Contracts;
using SportArete.Core.Data;
using SportArete.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportArete.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext _context,
                            UserManager<User> _userManager)
        {
            userManager = _userManager;
            context = _context;
        }

        public User GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}
