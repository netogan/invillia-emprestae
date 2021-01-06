using Emprestae.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace Emprestae.Application.Interfaces
{
    public interface IAmigoAppService : IDisposable
    {
        Task<AmigoViewModel> Adicionar(AmigoViewModel amigoViewModel);
        Task<AmigoViewModel> Atualizar(AmigoViewModel amigoViewModel);
        Task<AmigoViewModel> ObterPorId(Guid id);
        void Remover(Guid id);
    }
}
