using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cadastro.Infrastructure.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AppIdentityContext>
    {
        public AppIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityContext>();
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;Database=ClienteAPI; User Id=sa;Password=Dqs@2022;TrustServerCertificate=true");
            return new AppIdentityContext(optionsBuilder.Options);
        }
    }
}
