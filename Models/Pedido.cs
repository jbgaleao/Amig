using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Amigurumis.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdLinha { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public decimal ValorUnitario { get; set; }

        public virtual Linha VLinha { get; set; }
    }
}