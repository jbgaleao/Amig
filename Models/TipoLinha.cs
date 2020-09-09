using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("TipoLinha")]
    public class TipoLinha
    {

        public TipoLinha()
        {
            this.VLinhas = new HashSet<Linha>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }

        public virtual ICollection<Linha> VLinhas { get; set; }
    }
}