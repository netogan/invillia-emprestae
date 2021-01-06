using Emprestae.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestae.Infra.Data.EntityConfig
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");
            builder.HasKey(p => p.GameId);

            builder.Property(p => p.Nome).HasMaxLength(200);
            builder.Property(p => p.Genero).HasMaxLength(200);
            builder.Property(p => p.Desenvolvedores).HasMaxLength(200);
        }
    }
}
