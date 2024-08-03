using LocacaoVeiculos.AuthService.Models;
using LocacaoVeiculos.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.AuthService.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User?> LoginAsync(LoginModel user);
    }
}
