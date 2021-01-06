using AutoMapper;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Entities;

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
        }
    }
}
