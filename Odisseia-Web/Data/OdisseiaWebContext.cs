using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdisseiaWeb.Models;

namespace OdisseiaWeb.Models
{
    public class OdisseiaWebContext : DbContext
    {
        public OdisseiaWebContext (DbContextOptions<OdisseiaWebContext> options)
            : base(options)
        {
        }

        public DbSet<OdisseiaWeb.Models.Questao> Questao { get; set; }

        public DbSet<OdisseiaWeb.Models.Alternativa> Alternativa { get; set; }

        public DbSet<OdisseiaWeb.Models.Missao> Missao { get; set; }
    }
}
