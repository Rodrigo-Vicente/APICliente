using Cadastro.Application.DTOs;

namespace Cadastro.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAll();
        Task<ClienteDTO> GetById(int id);
        Task CreateCliente(ClienteDTO clienteDTO);
        Task UpdateCliente(ClienteDTO clienteDTO);
        Task DeleteCliente(int id);
    }
}
