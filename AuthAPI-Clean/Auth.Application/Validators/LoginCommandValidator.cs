using Auth.Application.Commands;
using FluentValidation;

namespace Auth.Application.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(o => o.UserName)
              .NotEmpty()
              .WithMessage("{UserName} is required")
              .NotNull()
              .MaximumLength(70)
              .WithMessage("{UserName} must not exceed 70 characters");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters");

        }
    }
}
