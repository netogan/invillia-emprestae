using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Emprestae.Services.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoAppService _amigoAppService;

        public AmigoController(IAmigoAppService amigoAppService)
        {
            _amigoAppService = amigoAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<ActionResult> Adicionar(AmigoViewModel amigo)
        {
            var ret = await _amigoAppService.Adicionar(amigo);

            return Ok(ret);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar(AmigoViewModel amigo)
        {
            if (amigo.AmigoId.GetValueOrDefault() == Guid.Empty)
                return BadRequest("Não foi informado o Id do amigo");

            var ret = await _amigoAppService.Atualizar(amigo);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<ActionResult> ObterPorId(Guid amigoId)
        {
            var ret = await _amigoAppService.ObterPorId(amigoId);

            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpDelete]
        [Route("Remover")]
        public async Task<ActionResult> Remover(Guid amigoId)
        {
            _amigoAppService.Remover(amigoId);

            return Ok();
        }

    }
}
