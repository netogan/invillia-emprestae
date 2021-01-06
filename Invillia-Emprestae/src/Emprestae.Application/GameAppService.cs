using AutoMapper;
using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Emprestae.Application
{
    public class GameAppService : IGameAppService
    {
        public readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameAppService(IMapper mapper, IGameService gameService)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        public async Task<GameViewModel> Adicionar(GameViewModel gameView)
        {
            var game = _mapper.Map<Game>(gameView);

            var ret = await _gameService.Adicionar(game);

            return _mapper.Map<GameViewModel>(ret);
        }

        public async Task<GameViewModel> Atualizar(GameViewModel gameView)
        {
            var game = _mapper.Map<Game>(gameView);

            var ret = await _gameService.Atualizar(game);

            return _mapper.Map<GameViewModel>(ret);
        }

        public async Task<GameViewModel> ObterPorId(Guid id)
        {
            var ret = await _gameService.ObterPorId(id);

            return _mapper.Map<GameViewModel>(ret);
        }

        public void Remover(Guid id)
        {
            _gameService.Remover(id);
        }

        public void Dispose()
        {
            _gameService.Dispose();
        }
    }
}
