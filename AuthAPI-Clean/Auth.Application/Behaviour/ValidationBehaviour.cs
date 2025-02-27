using Auth.Application.Responses;
using FluentValidation;
using MediatR;

namespace Auth.Application.Behaviour
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : IRequest<TResponse>
      where TResponse : AuthResponse, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validationResults.SelectMany(e => e.Errors).Where(f => f != null).ToList();

                if (failures.Count > 0)
                {
                    return new TResponse
                    {
                        Result = 0,
                        Message = "Validation failed",
                        Errors = failures
                            .Select(e => new ValidationError(e.PropertyName, e.ErrorMessage))
                            .ToList()
                    };
                }
            }

            return await next();
        }
    }

}
