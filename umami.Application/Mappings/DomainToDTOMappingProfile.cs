using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Application.DTOs;
using umami.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace umami.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<TIPOUSUARIO, TipoUsuarioDTO>().ReverseMap();
            CreateMap<USUARIO, UsuarioDTO>().ReverseMap();
        }
    }
}
