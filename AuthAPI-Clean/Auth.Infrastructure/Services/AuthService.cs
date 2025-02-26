using Auth.Core.Interfaces;
using Auth.Core.Result;
using Auth.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Auth.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenGeneratorService _tokenGenerator;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenGeneratorService tokenGenerator, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
            _logger = logger;
        }

        public async Task<AuthResult> Login(string? UserName, string? Password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(UserName);
                if (user == null)
                {
                    _logger.LogWarning("Login failed: User not found.");
                    return null; // Return a proper error response
                }
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, Password);
                if (!isPasswordValid)
                {
                    _logger.LogWarning("Login failed: Invalid password.");
                    return null; // Return a proper error response
                }

                List<Claim> claims = new()
                {
                     new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                // Generate JWT Token
                var token = _tokenGenerator.GenerateJwtToken(claims);

                return new AuthResult { Token = token, UserName = user.UserName };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                throw;
            }
        }
    }
}
