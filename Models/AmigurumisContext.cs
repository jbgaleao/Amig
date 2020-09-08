using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Amigurumis.Models
{
    public class AmigurumisContext : DbContext
    {

        public AmigurumisContext() : base ("ConnStrAmig")
        {

        }

        public DbSet<Foto> FOTOS { get; set; }
        public DbSet<Linha> LINHAS { get; set; }
        public DbSet<Receita> RECEITAS { get; set; }
        public DbSet<Revista> REVISTAS { get; set; }
        public DbSet<TipoLinha> TIPOSLINHA { get; set; }
        public DbSet<Fabricante> FABRICANTES { get; set; } 

    }
}