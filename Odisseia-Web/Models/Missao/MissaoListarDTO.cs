using System;

namespace Models.Missao
{
    public class MissaoListarDTO
    {
        public int id { get; set; }
        public int fkMissaoAluno { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public DateTime dataPrazo { get; set; }
    }
}
