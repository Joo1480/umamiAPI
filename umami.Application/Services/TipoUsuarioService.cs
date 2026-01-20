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

namespace umami.Application.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public TipoUsuarioService(ITipoUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TipoUsuarioDTO> Incluir(TipoUsuarioDTO tipoUsuDTO)
        {
            var tipoUsu = _mapper.Map<TIPOUSUARIO>(tipoUsuDTO);
            var tipoUsuIncluido = await _repository.Incluir(tipoUsu);
            return _mapper.Map<TipoUsuarioDTO>(tipoUsuIncluido);
        }
        public async Task<TipoUsuarioDTO> Alterar(TipoUsuarioDTO modelDTO)
        {
            var model = _mapper.Map<TIPOUSUARIO>(modelDTO);
            var modelAlterado = await _repository.Alterar(model);
            return _mapper.Map<TipoUsuarioDTO>(modelAlterado);
        }
        public async Task<TipoUsuarioDTO> Excluir(int id)
        {
            var tipoUsuExcluido = await _repository.Excluir(id);
            return _mapper.Map<TipoUsuarioDTO>(tipoUsuExcluido);
        }     

        public async Task<TipoUsuarioDTO> SelecionarAsync(int id)
        {
            var tipoUsu = await _repository.SelecionarAsync(id);
            return _mapper.Map<TipoUsuarioDTO>(tipoUsu);
        }

        public Task<IEnumerable<TipoUsuarioDTO>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
