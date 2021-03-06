﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Linha")]
    public class Linha
    {

        public Linha()
        {
            this.VPedido = new HashSet<Pedido>();
        }


        [Key]
        public int Id { get; set; }

        [Required]
        public int CodigoCor { get; set; }

        [Required]
        [MaxLength(50)]
        public string DescricaoCor { get; set; }

        [Required]
        public int QtdFechada { get; set; }

        [Required]
        public int QtdAberta { get; set; }

        public virtual TipoLinha VTipoLinha { get; set; }

        public virtual Fabricante VFabricante { get; set; }

        public virtual Receita VReceita { get; set; }        
        
        public virtual ICollection<Pedido> VPedido { get; set; }
    }
}