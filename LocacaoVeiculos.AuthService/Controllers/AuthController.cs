using LocacaoVeiculos.AuthService.Models;
using LocacaoVeiculos.AuthService.Services;
using LocacaoVeiculos.Shared.Controllers;
using LocacaoVeiculos.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoVeiculos.AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpGet("PIMBAS")]
        [AllowAnonymous]
        public string GetPimbas()
        {
            return "PIMBAS";
        }

        /// <summary>
        /// Method to register a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterUser(User user)
        {
            await _authService.RegisterUserAsync(user);
            return Created();
        }

        /// <summary>
        /// Method to update user information
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            if (user.Id != LoggedUserId)
            {
                return Unauthorized();
            }

            await _authService.UpdateUserAsync(user);
            return NoContent();
        }

        /// <summary>
        /// Method to delete a user
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteUser()
        {
            await _authService.DeleteUserAsync(LoggedUserId);
            return NoContent();
        }

        /// <summary>
        /// Method to login a user and generate a JWT token
        /// </summary>
        /// <param name="login">The login credentials</param>
        /// <returns>An object containing the JWT token</returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel login)
        {
            var user = new User()
            {
                Email = login.Email,
                Id = 1
            };//await _authService.LoginAsync(login);
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Issuer"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(tokenString);
            }

            return Unauthorized();
        }
    }
}
