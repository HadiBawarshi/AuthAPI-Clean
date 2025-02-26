using Auth.Application.Responses;
using Auth.Core.Result;
using AutoMapper;

namespace Auth.Application.Mappers
{
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<AuthResult, AuthResponse>()
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Token) ? 1 : 0))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Token) ? "Login successful" : "Login failed"));
        }
    }
}
