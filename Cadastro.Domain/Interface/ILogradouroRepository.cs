using Cadastro.Domain.Entity;

namespace Cadastro.Domain.Interface
{
    public interface ILogradouroRepository
    {
        Task<Logradouro> GetLogradouro(int id);
        Task<IEnumerable<Logradouro>> GetLogradouroByCliente(int id);
        Task<Logradouro> CreateLogradouro(Logradouro logradouro);
        Task<Logradouro> UpdateLogradouro(Logradouro logradouro);

        Task<Logradouro> DeleteLogradouro(Logradouro logradouro);
    }
}
