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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new AmigoConfig());
            modelBuilder.ApplyConfiguration(new EmprestimoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
