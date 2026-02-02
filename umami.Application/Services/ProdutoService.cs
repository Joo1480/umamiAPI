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
using umami.Infra.Data.Repositories;

namespace umami.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<ProdutoDTO> Incluir(ProdutoDTO modelDTO)
        {
            var model = _mapper.Map<PRODUTO>(modelDTO);
            var produtoIncluido = await _repository.Incluir(model);
            return _mapper.Map<ProdutoDTO>(produtoIncluido);
        }
        public async Task<ProdutoDTO> Alterar(ProdutoDTO modelDTO)
        {
            var model = _mapper.Map<PRODUTO>(modelDTO);
            var modelAlterado = await _repository.Alterar(model);
            return _mapper.Map<ProdutoDTO>(modelAlterado);
        }
        public async Task<ProdutoDTO> Excluir(int id)
        {
            var modelExcluido = await _repository.Excluir(id);
            return _mapper.Map<ProdutoDTO>(modelExcluido);
        }
        public async Task<ProdutoDTO> SelecionarAsync(int id)
        {
            var produto = await _repository.SelecionarAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }
        public async Task<PagedList<ProdutoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var model = await _repository.SelecionarTodosAsync(pageNumber, pageSize);
            var modelDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(model);

            return new PagedList<ProdutoDTO>(modelDTO, pageNumber, pageSize,model.TotalCount);
        }
    }
}
