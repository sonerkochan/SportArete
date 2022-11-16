using SportArete.Core.Contracts;
using SportArete.Infrastructure.Data.Common;
using SportArete.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SportArete.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;
        public CartService(IRepository _repo)
        {
            repo = _repo;
        }
    }
}