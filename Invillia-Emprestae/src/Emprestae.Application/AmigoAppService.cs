using AutoMapper;
using Emprestae.Application.Interfaces;
using Emprestae.Application.ViewModel;
using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Emprestae.Application
{
    public class AmigoAppService : IAmigoAppService
    {
        public readonly IAmigoService _amigoService;
        private readonly IMapper _mapper;

        public AmigoAppService(IMapper mapper, IAmigoService amigoService)
        {
            _mapper = mapper;
            _amigoService = amigoService;
        }

        public async Task<AmigoViewModel> Adicionar(AmigoViewModel amigoView)
        {
            var amigo = _mapper.Map<Amigo>(amigoView);

            var ret = await _amigoService.Adicionar(amigo);

            return _mapper.Map<AmigoViewModel>(ret);
        }

        public async Task<AmigoViewModel> Atualizar(AmigoViewModel amigoView)
        {
            var amigo = _mapper.Map<Amigo>(amigoView);

            var ret = await _amigoService.Atualizar(amigo);

            return _mapper.Map<AmigoViewModel>(ret);
        }

        public async Task<AmigoViewModel> ObterPorId(Guid id)
        {
            var ret = await _amigoService.ObterPorId(id);

            return _mapper.Map<AmigoViewModel>(ret);
        }

        public void Remover(Guid id)
        {
            _amigoService.Remover(id);
        }

        public void Dispose()
        {
            _amigoService.Dispose();
        }
    }
}
