using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        public string GetUserNameById(string userId);

    }
}
