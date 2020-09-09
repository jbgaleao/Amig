
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Fabricante")]
    public class Fabricante
    {

        public Fabricante()
        {
            this.VLinhas = new HashSet<Linha>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        public virtual ICollection<Linha> VLinhas { get; set; }
    }
}