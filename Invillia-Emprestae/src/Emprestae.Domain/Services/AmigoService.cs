using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Emprestae.Domain.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IAmigoRepository _amigoRepository;

        public AmigoService(IAmigoRepository amigoRepository)
        {
            _amigoRepository = amigoRepository;
        }

        public async Task<Amigo> Adicionar(Amigo amigo)
        {
            amigo.AmigoId = Guid.NewGuid();

            _amigoRepository.Adicionar(amigo);
            _amigoRepository.SaveChanges();

            return amigo;
        }

        public async Task<Amigo> Atualizar(Amigo amigo)
        {
            var amigoExistente = _amigoRepository.ObterPorIdNoTracking(amigo.AmigoId);

            if (amigoExistente == null)
                return null;

            _amigoRepository.Atualizar(amigo);

            _amigoRepository.SaveChanges();

            return amigo;
        }

        public async Task<Amigo> ObterPorId(Guid id)
        {
            return _amigoRepository.ObterPorId(id);
        }

        public void Remover(Guid id)
        {
            _amigoRepository.Remover(id);
            _amigoRepository.SaveChanges();
        }

        public void Dispose()
        {
            _amigoRepository.Dispose();
        }
    }
}
