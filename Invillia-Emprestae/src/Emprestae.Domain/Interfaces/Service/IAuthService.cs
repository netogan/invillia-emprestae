using Emprestae.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Emprestae.Domain.Interfaces.Service
{
    public interface IAuthService : IDisposable
    {
        Task<string> Registrar(IdentityUser identityUser, string password);
        Task<string> Login(IdentityUser identityUser, string password);
    }
}
