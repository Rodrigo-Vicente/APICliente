using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using Cadastro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private AppIdentityContext _appIdentityContext;

        public ClienteRepository(AppIdentityContext context)
        {
            _appIdentityContext = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _appIdentityContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _appIdentityContext.Clientes.Include(c => c.Logradouros)
              .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            _appIdentityContext.Add(cliente);
            await _appIdentityContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> DeleteCliente(Cliente cliente)
        {
            _appIdentityContext.Remove(cliente);
            await _appIdentityContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            _appIdentityContext.Update(cliente);
            await _appIdentityContext.SaveChangesAsync();
            return cliente;
        }
    }
}
