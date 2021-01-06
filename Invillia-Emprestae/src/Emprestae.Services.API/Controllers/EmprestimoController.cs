using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Emprestae.Services.API.Controllers
{
    [ApiController]
    [Route("Emprestimo")]
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
            var ret = await _emprestimoAppService.Adicionar(emprestimo);

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
        public async Task<ActionResult> ObterPorId(Guid id)
        {
            var ret = await _emprestimoAppService.ObterPorId(id);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<ActionResult> Remover(Guid id)
        {
            _emprestimoAppService.Remover(id);

            return Ok();
        }

    }
}
