using Emprestae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestae.Infra.Data.EntityConfig
{
    public class EmprestimoConfig : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimos");
            builder.HasKey(p => p.EmprestimoId);
        }
    }
}
