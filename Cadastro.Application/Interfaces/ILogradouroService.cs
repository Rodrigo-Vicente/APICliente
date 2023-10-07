using Cadastro.Application.DTOs;

namespace Cadastro.Application.Interfaces
{
    public interface ILogradouroService
    {
        Task<IEnumerable<LogradouroDTO>> GetLogradouro(int id);
        Task<IEnumerable<LogradouroDTO>> GetLogradouroByCliente(int id);
        Task CreateLogradouro(LogradouroDTO logradouro);
        Task UpdateLogradouro(LogradouroDTO logradouro);
        Task DeleteLogradouro(int id);
    }
}
