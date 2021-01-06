using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprestae.Domain.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IGameService _gameService;
        private readonly IAmigoService _amigoService;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IGameService gameService, IAmigoService amigoService)
        {
            _emprestimoRepository = emprestimoRepository;
            _gameService = gameService;
            _amigoService = amigoService;
        }

        public async Task<Emprestimo> Adicionar(Emprestimo emprestimo)
        {
            var game = await _gameService.ObterPorId(emprestimo.GameId);

            var amigo = await _amigoService.ObterPorId(emprestimo.AmigoId);

            if (game == null || amigo == null)
                return null;

            var emprestimosExistentes = _emprestimoRepository.Buscar(x => x.GameId == emprestimo.GameId).ToList();

            if (emprestimosExistentes.Count == game.Quantidade)
                return null;

            emprestimo.EmprestimoId = Guid.NewGuid();

            _emprestimoRepository.Adicionar(emprestimo);
            _emprestimoRepository.SaveChanges();

            return emprestimo;
        }

        public async Task<Emprestimo> Atualizar(Emprestimo emprestimo)
        {
            var emprestimoExistente = _emprestimoRepository.ObterPorIdNoTracking(emprestimo.EmprestimoId);

            if (emprestimoExistente == null)
                return null;

            _emprestimoRepository.Atualizar(emprestimo);

            _emprestimoRepository.SaveChanges();

            return emprestimo;
        }

        public async Task<Emprestimo> ObterPorId(Guid id)
        {
            return _emprestimoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Emprestimo>> ObterTodoPorAmigoId(Guid amigoId)
        {
            return _emprestimoRepository.Buscar(x => x.AmigoId == amigoId);
        }

        public async Task<IEnumerable<Emprestimo>> ObterTodoPorGameId(Guid gameId)
        {
            return _emprestimoRepository.Buscar(x => x.GameId == gameId);
        }

        public void Remover(Guid id)
        {
            _emprestimoRepository.Remover(id);
        }

        public void Dispose()
        {
            _emprestimoRepository.Dispose();
        }
    }
}
