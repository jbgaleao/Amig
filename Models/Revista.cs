using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Revista")]
    public class Revista
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TituloTema { get; set; }
        [Required]
        public int NumeroEdicao { get; set; }
        [Required]
        public string FotoCapa { get; set; }

        public virtual ICollection<Receita> VReceita { get; set; }
    }
}