using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Emprestae.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameAppService _gameAppService;

        public GameController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult> Adicionar(GameViewModel game)
        {
            if (!ModelState.IsValid) return BadRequest("Faltam informações para criar o game");

            var ret = await _gameAppService.Adicionar(game);

            return Ok(ret);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar(GameViewModel game)
        {
            if (game.GameId.GetValueOrDefault() == Guid.Empty)
                return BadRequest("Não foi informado o Id do game");

            var ret = await _gameAppService.Atualizar(game);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<ActionResult> ObterPorId(Guid gameId)
        {
            var ret = await _gameAppService.ObterPorId(gameId);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<ActionResult> Remover(Guid gameId)
        {
            _gameAppService.Remover(gameId);

            return Ok();
        }

    }
}
