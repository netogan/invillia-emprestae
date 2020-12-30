using System;

namespace Emprestae.Domain.Entities
{
    public class Emprestimo
    {
        public Guid EmprestimoId { get; set; }
        public Guid GameId { get; set; }
        public Guid AmigoId { get; set; }
        public DateTime DataEmprestimo { get; set; }
    }
}
