using AutoMapper;
using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestae.Application
{
    public class EmprestimoAppService : IEmprestimoAppService
    {
        public readonly IEmprestimoService _emprestimoService;
        private readonly IMapper _mapper;

        public EmprestimoAppService(IMapper mapper, IEmprestimoService emprestimoService)
        {
            _mapper = mapper;
            _emprestimoService = emprestimoService;
        }

        public async Task<EmprestimoViewModel> Adicionar(EmprestimoViewModel emprestimoView)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoView);

            var ret = await _emprestimoService.Adicionar(emprestimo);

            return _mapper.Map<EmprestimoViewModel>(ret);
        }

        public async Task<EmprestimoViewModel> Atualizar(EmprestimoViewModel emprestimoView)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoView);

            var ret = await _emprestimoService.Atualizar(emprestimo);

            return _mapper.Map<EmprestimoViewModel>(ret);
        }

        public async Task<EmprestimoViewModel> ObterPorId(Guid id)
        {
            var ret = await _emprestimoService.ObterPorId(id);

            return _mapper.Map<EmprestimoViewModel>(ret);
        }

        public async Task<IEnumerable<EmprestimoViewModel>> ObterTodosPorAmigoId(Guid amigoId)
        {
            var ret = await _emprestimoService.ObterTodoPorAmigoId(amigoId);

            return _mapper.Map<IEnumerable<EmprestimoViewModel>>(ret);
        }

        public async Task<IEnumerable<EmprestimoViewModel>> ObterTodosPorGameId(Guid gameId)
        {
            var ret = await _emprestimoService.ObterTodoPorGameId(gameId);

            return _mapper.Map<IEnumerable<EmprestimoViewModel>>(ret);
        }

        public void Remover(Guid id)
        {
            _emprestimoService.Remover(id);
        }

        public void Dispose()
        {
            _emprestimoService.Dispose();
        }
    }
}
