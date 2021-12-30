using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Informe seu nome completo.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe sua idade.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string? CPF { get; set; }

        [ForeignKey("Viagem")]
        public int Id_Viagem { get; set; }
        public virtual Viagem Viagem { get; set; }

    }

}