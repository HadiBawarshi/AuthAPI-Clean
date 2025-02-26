using Auth.Application.Commands;
using Auth.Application.Responses;
using Auth.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace Auth.Application.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResult = await _authService.Login(request?.UserName, request?.Password);
            if (authResult == null)
            {
                return new AuthResponse
                {
                    Result = 0,
                    Message = "Invalid username or password",
                    Errors = new List<ValidationError> { new ValidationError("Login", "Invalid credentials.") }
                };
            }
            return _mapper.Map<AuthResponse>(authResult); // Mapping here
        }
    }
}
