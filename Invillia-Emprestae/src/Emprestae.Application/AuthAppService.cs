using AutoMapper;
using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Emprestae.Application
{
    public class AuthAppService : IAuthAppService
    {
        public readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthAppService(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<string> Registrar(RegisterUserViewModel registerUser)
        {
            var identityUser = _mapper.Map<IdentityUser>(registerUser);

            var ret = await _authService.Registrar(identityUser, registerUser.Password);

            return ret;
        }

        public async Task<string> Login(LoginUserViewModel loginUser)
        {
            var identityUser = _mapper.Map<IdentityUser>(loginUser);

            var ret = await _authService.Login(identityUser, loginUser.Password);

            return ret;
        }

        public void Dispose()
        {
            _authService.Dispose();
        }
    }
}
