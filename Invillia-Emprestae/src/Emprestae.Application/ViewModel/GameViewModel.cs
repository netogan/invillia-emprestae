using System;

namespace Emprestae.Application.ViewModel
{
    public class GameViewModel
    {
        public Guid? GameId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Desenvolvedores { get; set; }
        public int? Quantidade { get; set; }
    }
}
