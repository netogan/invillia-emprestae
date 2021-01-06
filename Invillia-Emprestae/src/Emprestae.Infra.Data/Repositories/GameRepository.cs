using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Infra.Data.Context;

namespace Emprestae.Infra.Data.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
