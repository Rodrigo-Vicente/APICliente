using Cadastro.Domain.Entity;
using Cadastro.Domain.Interface;
using Cadastro.Infrastructure.Context;

namespace Cadastro.Infrastructure.Repository
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private AppIdentityContext _appIdentityContext;

        public LogradouroRepository(AppIdentityContext context)
        {
            _appIdentityContext = context;
        }
        public async Task<Logradouro> GetLogradouro(int id)
        {
            return await _appIdentityContext.Logradouros.FindAsync(id);

        }

        public async Task<Logradouro> GetLogradouroByCliente(int id)
        {
            return await _appIdentityContext.Logradouros.FindAsync(id);
        }
        public async Task<Logradouro> CreateLogradouro(Logradouro logradouro)
        {
            _appIdentityContext.Add(logradouro);
            await _appIdentityContext.SaveChangesAsync();
            return logradouro;
        }

        public async Task<Logradouro> UpdateLogradouro(Logradouro logradouro)
        {
            _appIdentityContext.Update(logradouro);
            await _appIdentityContext.SaveChangesAsync();
            return logradouro;
        }

        public async Task<Logradouro> DeleteLogradouro(Logradouro logradouro)
        {
            _appIdentityContext.Remove(logradouro);
            await _appIdentityContext.SaveChangesAsync();
            return logradouro;
        }
    }
}
