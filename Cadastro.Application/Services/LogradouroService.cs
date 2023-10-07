using AutoMapper;
using Cadastro.Application.DTOs;
using Cadastro.Application.Interfaces;
using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;

namespace Cadastro.Application.Services
{
    public class LogradouroService : ILogradouroService
    {
        private readonly ILogradouroRepository _logradouroRepository;
        private readonly IMapper _mapper;
        public LogradouroService(ILogradouroRepository logradouroRepository, IMapper mapper)
        {
            _logradouroRepository = logradouroRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LogradouroDTO>> GetLogradouro(int id)
        {
            var logradouro = await _logradouroRepository.GetLogradouro(id);
            return _mapper.Map<IEnumerable<LogradouroDTO>>(logradouro);
        }

        public async Task<IEnumerable<LogradouroDTO>> GetLogradouroByCliente(int id)
        {
            var logradouro = await _logradouroRepository.GetLogradouro(id);
            return _mapper.Map<IEnumerable<LogradouroDTO>>(logradouro);
        }
        public async Task CreateLogradouro(LogradouroDTO logradouroDTO)
        {
            var logradouro = _mapper.Map<Logradouro>(logradouroDTO);
            await _logradouroRepository.CreateLogradouro(logradouro);
        }

        public async Task DeleteLogradouro(int id)
        {
            var logradouro = _logradouroRepository.GetLogradouro(id).Result;
            await _logradouroRepository.DeleteLogradouro(logradouro);
        }

        public async Task UpdateLogradouro(LogradouroDTO logradouroDTO)
        {
            var logradouro = _mapper.Map<Logradouro>(logradouroDTO);
            await _logradouroRepository.UpdateLogradouro(logradouro);
        }
    }
}
