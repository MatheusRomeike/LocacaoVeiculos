using LocacaoVeiculos.AuthService.Models;
using LocacaoVeiculos.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.AuthService.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User?> LoginAsync(LoginModel user);
    }
}
