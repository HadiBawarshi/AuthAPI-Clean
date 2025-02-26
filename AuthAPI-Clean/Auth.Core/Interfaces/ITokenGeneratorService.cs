using System.Security.Claims;

namespace Auth.Core.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateJwtToken(List<Claim> claims);
    }
}
