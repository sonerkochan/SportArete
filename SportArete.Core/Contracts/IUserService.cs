using SportArete.Core.Models.User;
using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        public string GetUserNameById(string userId);

        Task<IEnumerable<UserServiceModel>> All();

        //Task<bool> Forget(string userId);

    }
}
