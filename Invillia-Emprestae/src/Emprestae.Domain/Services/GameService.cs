using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Emprestae.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Game> Adicionar(Game game)
        {
            game.GameId = Guid.NewGuid();

            _gameRepository.Adicionar(game);
            _gameRepository.SaveChanges();

            return game;
        }

        public async Task<Game> Atualizar(Game game)
        {
            var gameExistente = _gameRepository.ObterPorIdNoTracking(game.GameId);

            if (gameExistente == null)
                return null;

            _gameRepository.Atualizar(game);

            _gameRepository.SaveChanges();

            return game;
        }

        public async Task<Game> ObterPorId(Guid id)
        {
            return _gameRepository.ObterPorId(id);
        }

        public void Remover(Guid id)
        {
            _gameRepository.Remover(id);
        }

        public void Dispose()
        {
            _gameRepository.Dispose();
        }
    }
}
