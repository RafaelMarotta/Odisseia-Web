using System.Collections.Generic;

namespace OdisseiaWeb.Models
{
    public class Questao
    {
        public IEnumerable<Alternativa> Alternativas { get; set; }
        public int Id { get; set; }
        public int FkMissao { get; set; }
        public int Dificuldade { get; set; }
        public string Enunciado { get; set; }
        public bool Excluido { get; set; }
    }
}
