using System;
using System.Collections.Generic;
using Models.Questao;

namespace Models.Missao
{
    public class MissaoCreateDTO
    {
        public string titulo { get; set; }
        public string descricao { get; set; }
        public int fkMateria { get; set; }
        public int fkCriador { get; set; }
        public IList<QuestaoCreateDTO> questoes { get; set; }
    }
}

