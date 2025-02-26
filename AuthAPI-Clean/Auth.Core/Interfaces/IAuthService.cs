using Auth.Core.Result;

namespace Auth.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Login(string? UserName, string? Password);

    }
}
