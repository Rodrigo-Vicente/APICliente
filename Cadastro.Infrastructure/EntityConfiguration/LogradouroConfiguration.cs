using Cadastro.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.EntityConfiguration
{
    public class LogradouroConfiguration : IEntityTypeConfiguration<Logradouro>
    {
        public void Configure(EntityTypeBuilder<Logradouro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasOne(e => e.Cliente).WithMany(e => e.Logradouros)
                .HasForeignKey(e => e.ClienteId);
        }
    }
}
