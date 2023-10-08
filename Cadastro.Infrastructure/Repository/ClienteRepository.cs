using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using Cadastro.Infrastructure.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cadastro.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private AppIdentityContext _appIdentityContext;
        private IConfiguration _configuration;

        public ClienteRepository(AppIdentityContext context, IConfiguration configuration)
        {
            _appIdentityContext = context;
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var conection = _configuration.GetConnectionString("DefaultConnection");
            return conection;
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
            var connectionString = this.GetConnection();
            var query = $"EXECUTE [dbo].[CREATENewCliente] = [dbo].[CREATENewCliente]  @Nome = {cliente.Nome}," +
                $"@Email={cliente.Email}," +
                $"@Logotiponame={null}" +
                $",@Logo={null}" +
                $"GO";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var queryExecute = await connection.ExecuteAsync(query);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return cliente;
        }

        public async Task<Cliente> DeleteCliente(Cliente cliente)
        {
            var connectionString = this.GetConnection();
            var query = $"EXECUTE [dbo].[DeleteCliente] " +
                $"@Id = {cliente.Id}"+
                $"GO";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var queryExecute = await connection.ExecuteAsync(query);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            var connectionString = this.GetConnection();
            var query = $"EXECUTE [dbo].[UpdateCliente] " +
                $"@Id = {cliente.Id}," +
                $" @Nome = {cliente.Nome}, " +
                $" @Email={cliente.Email}, " +
                $" @Logotiponame={null} " +
                $",@Logo={null} " +
                $"GO";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var queryExecute = await connection.ExecuteAsync(query);

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
            return cliente;
        }
    }
}
