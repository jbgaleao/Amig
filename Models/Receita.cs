using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Receita")]
    public class Receita
    {

        public Receita()
        {
            this.VLinhas = new HashSet<Linha>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(256)]
        public string Descricao { get; set; }

        [Required]
        public string foto { get; set; }

        [Required]
        public int IdRevista { get; set; }

        public virtual Revista VRevista { get; set; }

        public virtual ICollection<Linha> VLinhas { get; set; }


    }
}