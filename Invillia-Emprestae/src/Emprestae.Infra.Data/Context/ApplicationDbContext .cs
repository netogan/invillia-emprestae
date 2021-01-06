using Emprestae.Domain.Entities;
using Emprestae.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Emprestae.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public IDbContextTransaction Transaction { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GameConfig());
            builder.ApplyConfiguration(new AmigoConfig());
            builder.ApplyConfiguration(new EmprestimoConfig());

            base.OnModelCreating(builder);
        }
    }
}
