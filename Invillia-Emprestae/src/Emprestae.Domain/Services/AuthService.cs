using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Service;
using Emprestae.Infra.CrossCutting.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestae.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<string> Registrar(IdentityUser identityUser, string password)
        {
            var result = await _userManager.CreateAsync(identityUser, password);

            if (!result.Succeeded)
                return null;

            await _signInManager.SignInAsync(identityUser, false);

            return "Logado com sucesso";
        }

        public async Task<string> Login(IdentityUser identityUser, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(identityUser.UserName, password, false, true);

            if (!result.Succeeded)
                return null;

            var token = await GerarJwt(identityUser.Email);

            return token;
        }

        public async Task<string> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}
