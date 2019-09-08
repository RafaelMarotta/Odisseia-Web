using System;
using System.Collections.Generic;

namespace OdisseiaWeb.Models
{
    public class Missao
    {
        public IEnumerable<Questao> questoes { get; set; }
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int fkMateria { get; set; }
        public int fkCriador { get; set; }
        public DateTime dataCriacao { get; set; }
        public DateTime dataPrazo { get; set; }
        public bool lancada { get; set; }
        public bool excluido { get; set; }
    }
}
