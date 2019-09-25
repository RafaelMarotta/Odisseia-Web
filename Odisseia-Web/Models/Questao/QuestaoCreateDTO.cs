using System;
using System.Collections.Generic;
using Models.Alternativa;

namespace Models.Questao
{
    public class QuestaoCreateDTO
    {
        public string enunciado { get; set; }
        public int dificuldade { get; set; }
        public IList<AlternativaCreateDTO> alternativas { get; set; }
    }
}

