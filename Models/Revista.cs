using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Revista")]
    public class Revista
    {

        public Revista()
        {
            this.VReceita = new HashSet<Receita>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Tema { get; set; }
        [Required]
        public int NumeroEdicao { get; set; }
        [Required]
        public string FotoCapa { get; set; }

        public virtual ICollection<Receita> VReceita { get; set; }
    }
}