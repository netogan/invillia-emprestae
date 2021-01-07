using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Emprestae.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

            var ret = await _authAppService.Registrar(registerUser);

            if (ret == null)
                BadRequest("Não foi possível cadastrar o usuário");

            return Ok(ret);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));

            var ret = await _authAppService.Login(loginUser);

            if (ret == null)
                BadRequest("Usuário ou senha inválidos");

            return Ok(ret);
        }

    }
}
