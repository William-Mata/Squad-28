using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Pacote")]
    public class Pacote
    {
        [Key]
        public int IdPacote { get; set; }

        [Required(ErrorMessage = "Informe o valor do pacote.")]
        public string? Valor { get; set; }

        [Required(ErrorMessage = "A data de inicio.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de final.")]
        public DateTime DataFim { get; set; }



        [ForeignKey("Imagem")]
        public int IdImagem { get; set; }
        public virtual List<Imagem>? Imagens { get; set; }



        [ForeignKey("Tribo")]
        public int IdTribo { get; set; }
        public virtual TriboParceira? TriboParceira { get; set; }

    }
}
