using SportArete.Infrastructure.Data.Models;

namespace SportArete.Core.Contracts
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
    }
}
