using Emprestae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestae.Infra.Data.EntityConfig
{
    public class AmigoConfig : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.ToTable("Amigos");
            builder.HasKey(p => p.AmigoId);

            builder.Property(p => p.Nome).HasMaxLength(200);
        }
    }
}
