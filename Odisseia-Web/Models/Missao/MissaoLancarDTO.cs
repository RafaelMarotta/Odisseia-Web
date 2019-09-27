using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Missao
{
    public class MissaoLancarDTO
    {
        public long DataPrazo { get; set; }
        public int MissaoId { get; set; }
    }
}
