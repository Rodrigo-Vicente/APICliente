using AutoMapper;
using Cadastro.Application.DTOs;
using Cadastro.Domain.Entity;

namespace Cadastro.Application.Mappings
{
    public class MappingToDomain : Profile
    {
        public MappingToDomain()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Logradouro, LogradouroDTO>().ReverseMap();
        }
    }
}
