using Auth.Application.Responses;
using MediatR;


namespace Auth.Application.Commands
{
    public class LoginCommand : IRequest<AuthResponse>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
