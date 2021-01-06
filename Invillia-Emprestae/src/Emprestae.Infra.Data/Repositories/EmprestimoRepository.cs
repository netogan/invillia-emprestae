using Emprestae.Domain.Entities;
using Emprestae.Domain.Interfaces.Repository;
using Emprestae.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace Emprestae.Infra.Data.Repositories
{
    public class EmprestimoRepository : RepositoryBase<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
