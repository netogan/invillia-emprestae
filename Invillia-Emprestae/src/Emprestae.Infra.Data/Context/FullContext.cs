using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Emprestae.Infra.Data.Context
{
    public class FullContext : DbContext
    {
        public IDbContextTransaction Transaction { get; set; }

        public FullContext(DbContextOptions options) : base(options)
        {

        }
    }
}
