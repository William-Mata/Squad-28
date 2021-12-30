using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Viagem")]
    public class Viagem
    {

        [Key]
        public int IdViagem { get; set; }

        [Required(ErrorMessage = "Informe a origem de sua viagem.")]
        public string Origem { get; set; }

        [ForeignKey("Pacote")]
        public int Id_Pacote { get; set; }
        public virtual Pacote Pacote { get; set; }

        public virtual Cliente Cliente { get; set; }
        
    }


}