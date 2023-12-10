﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportArete.Core.Contracts;
using SportArete.Core.Models.User;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using System.ComponentModel;

namespace SportArete.Core.Services
{
    /// <summary>
    /// This Service is responsible for dealing with action relating the users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public UserService(
            IRepository _repo,
            UserManager<User> _userManager)
        {
            repo = _repo;
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
        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<User>()
                .Where(u => u.IsActive)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    UserName = u.UserName
                })
                .ToListAsync();

            return result;
        }

        
        public async Task<bool> Forget(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            user.Email = "N/A";
            user.IsActive = false;
            user.NormalizedEmail = "N/A";
            user.NormalizedUserName = "N/A";
            user.PasswordHash = "N/A";
            user.UserName = $"forgottenUser-{DateTime.Now.Ticks}";

            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
