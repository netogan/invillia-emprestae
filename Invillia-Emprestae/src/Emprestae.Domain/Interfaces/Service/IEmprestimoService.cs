using Emprestae.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestae.Domain.Interfaces.Service
{
    public interface IEmprestimoService : IDisposable
    {
        Task<Emprestimo> Adicionar(Emprestimo emprestimo);
        Task<Emprestimo> ObterPorId(Guid id);
        Task<IEnumerable<Emprestimo>> ObterTodoPorAmigoId(Guid amigoId);
        Task<IEnumerable<Emprestimo>> ObterTodoPorGameId(Guid gameId);
        Task<Emprestimo> Atualizar(Emprestimo emprestimo);
        void Remover(Guid id);
    }
}
