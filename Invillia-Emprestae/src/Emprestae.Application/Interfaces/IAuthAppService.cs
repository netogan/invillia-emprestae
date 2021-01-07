using Emprestae.Application.ViewModel;
using System;
using System.Threading.Tasks;

namespace Emprestae.Application.Interfaces
{
    public interface IAuthAppService : IDisposable
    {
        Task<string> Registrar(RegisterUserViewModel registerUser);
        Task<string> Login(LoginUserViewModel loginUser);
    }
}
