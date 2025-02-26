using Auth.Core.Result;

namespace Auth.Application.Responses
{
    public partial class AuthResponse : AuthResult
    {
        public int? Result { get; set; }
        public List<ValidationError>? Errors { get; set; }
        public string? Message { get; set; }
    }

    public partial class ValidationError
    {
        public string? Field { get; set; }
        public string? Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }

    }
}
