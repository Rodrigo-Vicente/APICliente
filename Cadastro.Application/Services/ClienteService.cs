using AutoMapper;
using Cadastro.Application.DTOs;
using Cadastro.Application.Interfaces;
using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using System.Linq;

namespace Cadastro.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            var cliente = await _clienteRepository.GetAll();
            return _mapper.Map<IEnumerable<ClienteDTO>>(cliente);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var cliente = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }
        public async Task CreateCliente(ClienteDTO clienteDTO)
        {

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = _clienteRepository.GetById(id).Result;
            await _clienteRepository.DeleteCliente(cliente);
        }

        public async Task UpdateCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.UpdateCliente(cliente);
        }
    }
}
