using System;
using System.Collections.Generic;
using System.Text;

namespace Emprestae.Application.ViewModel
{
    public class EmprestimoViewModel
    {
        public Guid? EmprestimoId { get; set; }
        public Guid GameId { get; set; }
        public Guid AmigoId { get; set; }
        public DateTime? DataEmprestimo { get; set; }
    }
}
