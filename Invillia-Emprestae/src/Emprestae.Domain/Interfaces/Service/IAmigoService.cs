using Emprestae.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Emprestae.Domain.Interfaces.Service
{
    public interface IAmigoService : IDisposable
    {
        Task<Amigo> Adicionar(Amigo amigo);
        Task<Amigo> ObterPorId(Guid id);
        Task<Amigo> Atualizar(Amigo amigo);
        void Remover(Guid id);
    }
}
