using AutoMapper;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Emprestae.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<GameViewModel, Game>();

            CreateMap<Amigo, AmigoViewModel>();
            CreateMap<AmigoViewModel, Amigo>();

            CreateMap<Emprestimo, EmprestimoViewModel>();
            CreateMap<EmprestimoViewModel, Emprestimo>();

            CreateMap<RegisterUserViewModel, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true));

            CreateMap<LoginUserViewModel, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true));
        }
    }
}
