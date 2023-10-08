using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using Cadastro.Infrastructure.Context;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Cadastro.Infrastructure.Repository
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private AppIdentityContext _appIdentityContext;
        private IConfiguration _configuration;

        public LogradouroRepository(AppIdentityContext context, IConfiguration configuration)
        {
            _appIdentityContext = context;
            _configuration = configuration;
        }
        public string GetConnection()
        {
            var conection = _configuration.GetConnectionString("DefaultConnection");
            return conection;
        }
        public async Task<Logradouro> GetLogradouro(int id)
        {
            return await _appIdentityContext.Logradouros.FindAsync(id);

        }

        public async Task<IEnumerable<Logradouro>> GetLogradouroByCliente(int id)
        {
            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@ClienteId", id);


            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Logradouro>("dbo.GetLogradouroByCliente", parameters, commandType: CommandType.StoredProcedure);
                    return results;
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
        }
        public async Task<Logradouro> CreateLogradouro(Logradouro logradouro)
        {
            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Endereco", logradouro.Endereco);
            parameters.Add("@Bairro", logradouro.Bairro);
            parameters.Add("@Numero", logradouro.Numero);
            parameters.Add("@Cidade", logradouro.Cidade);
            parameters.Add("@Estado", logradouro.Estado);
            parameters.Add("@Pais", logradouro.Pais);
            parameters.Add("@Cep", logradouro.Cep);
            parameters.Add("@ClienteId", logradouro.ClienteId);


            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Logradouro>("dbo.CreateLogradouro", parameters, commandType: CommandType.StoredProcedure);
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
            return logradouro;
        }

        public async Task<Logradouro> UpdateLogradouro(Logradouro logradouro)
        {
            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", logradouro.Id);
            parameters.Add("@Endereco", logradouro.Endereco);
            parameters.Add("@Bairro", logradouro.Bairro);
            parameters.Add("@Numero", logradouro.Numero);
            parameters.Add("@Cidade", logradouro.Cidade);
            parameters.Add("@Estado", logradouro.Estado);
            parameters.Add("@Pais", logradouro.Pais);
            parameters.Add("@Cep", logradouro.Cep);
            parameters.Add("@ClienteId", logradouro.ClienteId);


            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Logradouro>("dbo.UpdateLogradouro", parameters, commandType: CommandType.StoredProcedure);
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
            return logradouro;
        }

        public async Task<Logradouro> DeleteLogradouro(Logradouro logradouro)
        {
            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Id", logradouro.Id);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var results = await connection.QueryAsync<Logradouro>("dbo.DeleteLogradouro", parameters, commandType: CommandType.StoredProcedure);

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
            return logradouro;
        }
    }
}
