using Emprestae.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Emprestae.Domain.Interfaces.Service
{
    public interface IGameService : IDisposable
    {
        Task<Game> Adicionar(Game game);
        Task<Game> ObterPorId(Guid id);
        Task<Game> Atualizar(Game game);
        void Remover(Guid id);
    }
}
