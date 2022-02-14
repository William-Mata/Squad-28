using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pindorama.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }

        [ForeignKey("Cliente")]
        public int? Id_Cliente { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("Contato")]
        public int? Id_Contato { get; set; }
        public virtual Contato? Contato { get; set; }

        [ForeignKey("AldeiaParceira")]
        public int? Id_AldeiaParceira { get; set; }
        public virtual AldeiaParceira? AldeiaParceira { get; set; }

        [ForeignKey("Pacote")]
        public int? Id_Pacote { get; set; }
        public virtual Pacote? Pacote { get; set; }

      
    }
}
