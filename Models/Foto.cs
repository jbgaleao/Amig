using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amigurumis.Models
{
    [Table("Foto")]
    public class Foto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string PathFoto { get; set; }

        public int IdReceita { get; set; }

        public virtual Receita VReceita { get; set; }

    }
}