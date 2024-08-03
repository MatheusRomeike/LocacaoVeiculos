using LocacaoVeiculos.AuthService.Models;
using LocacaoVeiculos.AuthService.Repositories;
using LocacaoVeiculos.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            var registeredUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (registeredUser != null)
                return false;
            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task UpdateUserAsync(User user)
        {
            var registeredUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (registeredUser != null && user.Id != registeredUser.Id)
                throw new Exception("Email already in use");
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<User?> LoginAsync(LoginModel user)
        {
            return await _userRepository.LoginAsync(user);
        }
    }
}
