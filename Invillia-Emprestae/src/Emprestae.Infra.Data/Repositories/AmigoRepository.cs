using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Infra.Data.Context;

namespace Emprestae.Infra.Data.Repositories
{
    public class AmigoRepository : RepositoryBase<Amigo>, IAmigoRepository
    {
        public AmigoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
