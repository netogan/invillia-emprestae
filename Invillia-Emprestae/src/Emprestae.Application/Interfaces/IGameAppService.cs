using Emprestae.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace Emprestae.Application.Interfaces
{
    public interface IGameAppService : IDisposable
    {
        Task<GameViewModel> Adicionar(GameViewModel gameViewModel);
        Task<GameViewModel> Atualizar(GameViewModel gameViewModel);
        Task<GameViewModel> ObterPorId(Guid id);
        void Remover(Guid id);
    }
}
