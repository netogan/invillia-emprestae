using Emprestae.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestae.Application.Interfaces
{
    public interface IEmprestimoAppService : IDisposable
    {
        Task<EmprestimoViewModel> Adicionar(EmprestimoViewModel emprestimoViewModel);
        Task<EmprestimoViewModel> Atualizar(EmprestimoViewModel emprestimoViewModel);
        Task<EmprestimoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<EmprestimoViewModel>> ObterTodosPorAmigoId(Guid amigoId);
        Task<IEnumerable<EmprestimoViewModel>> ObterTodosPorGameId(Guid gameId);
        void Remover(Guid id);
    }
}
