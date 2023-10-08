using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using Cadastro.Infrastructure.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

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
            var parameters = new DynamicParameters();
            parameters.Add("@Nome", cliente.Nome);
            parameters.Add("@Email", cliente.Email);
            parameters.Add("@Logotiponame", cliente.LogotipoName);
            parameters.Add("@Logo", cliente.Logo);
            
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Cliente>("dbo.CREATENewCliente", parameters, commandType: CommandType.StoredProcedure);

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
            var parameters = new DynamicParameters();
            parameters.Add("@Id", cliente.Id);
            
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Cliente>("dbo.DeleteCliente", parameters, commandType: CommandType.StoredProcedure);

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
            var parameters = new DynamicParameters();
            parameters.Add("@Id", cliente.Id);
            parameters.Add("@Nome", cliente.Nome);
            parameters.Add("@Emai", cliente.Email);
            parameters.Add("@Logotiponame", null);
            parameters.Add("@Logo", null);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Cliente>("dbo.DeleteCliente", parameters, commandType: CommandType.StoredProcedure);

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
