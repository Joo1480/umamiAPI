using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Application.Interfaces;
using umami.Domain.Entities;
using umami.Domain.Interfaces;
using umami.Domain.Pagination;

namespace umami.Application.Services
{
    public class TipoPagamentoService : ITipoPagamentoService
    {
        private readonly ITipoPagamentoRepository _repository;
        private readonly IMapper _mapper;

        public TipoPagamentoService(ITipoPagamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TipoPagamentoDTO> Incluir(TipoPagamentoDTO tipopagDTO)
        {
            var tipoPag = _mapper.Map<TIPOPAGAMENTO>(tipopagDTO);
            var tipoPagIncluido = await _repository.Incluir(tipoPag);
            return _mapper.Map<TipoPagamentoDTO>(tipoPagIncluido);
        }
        public async Task<TipoPagamentoDTO> Alterar(TipoPagamentoDTO modelDTO)
        {
            var model = _mapper.Map<TIPOPAGAMENTO>(modelDTO);
            var modelAlterado = await _repository.Alterar(model);
            return _mapper.Map<TipoPagamentoDTO>(modelAlterado);
        }
        public async Task<TipoPagamentoDTO> Excluir(int id)
        {
            var tipoPagExcluido = await _repository.Excluir(id);
            return _mapper.Map<TipoPagamentoDTO>(tipoPagExcluido);
        }

        public async Task<TipoPagamentoDTO> SelecionarAsync(int id)
        {
            var tipoPag = await _repository.SelecionarAsync(id);
            return _mapper.Map<TipoPagamentoDTO>(tipoPag);
        }

        public async Task<PagedList<TipoPagamentoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var tipoPagamentos = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
            var tipoPagamentosDTO = _mapper.Map<IEnumerable<TipoPagamentoDTO>>(tipoPagamentos);

            return new PagedList<TipoPagamentoDTO>(tipoPagamentosDTO, pageNumber, pageSize, tipoPagamentos.TotalCount);
        }
    }
}
