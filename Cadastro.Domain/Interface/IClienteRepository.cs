using Cadastro.Domain.Entity;

namespace Cadastro.Domain.Interface
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task<Cliente> CreateCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<Cliente> DeleteCliente(Cliente cliente);
    }
}
