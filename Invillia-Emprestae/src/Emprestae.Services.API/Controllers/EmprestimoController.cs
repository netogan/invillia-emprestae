using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Emprestae.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoAppService _emprestimoAppService;

        public EmprestimoController(IEmprestimoAppService emprestimoAppService)
        {
            _emprestimoAppService = emprestimoAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult> Adicionar(EmprestimoViewModel emprestimo)
        {
            if (emprestimo.GameId == null || emprestimo.AmigoId == null)
                return BadRequest("O identificador do amigo ou do game está ausente");

            var ret = await _emprestimoAppService.Adicionar(emprestimo);

            if (ret == null)
                return BadRequest("Não é possível fazer mais empréstimos para esse game. Todos já estão emprestados");

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterTodoPorAmigoId")]
        public async Task<ActionResult> ObterTodoPorAmigoId(Guid amigoId)
        {
            var ret = await _emprestimoAppService.ObterTodosPorAmigoId(amigoId);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterTodoPorGameId")]
        public async Task<ActionResult> ObterTodoPorGameId(Guid gameId)
        {
            var ret = await _emprestimoAppService.ObterTodosPorGameId(gameId);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<ActionResult> ObterPorId(Guid emprestimoId)
        {
            var ret = await _emprestimoAppService.ObterPorId(emprestimoId);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<ActionResult> Remover(Guid emprestimoId)
        {
            _emprestimoAppService.Remover(emprestimoId);

            return Ok();
        }

    }
}
