using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pindorama.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Informe seu nome completo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe um numero de celular para contato com a aldeia.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Informe sua idade.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }

        public string? Origem { get; set; }


        [ForeignKey("Pacote")]
        public virtual List<Pacote>? Pacote { get; set; }

        [ForeignKey("Artesanato")]
        public virtual List<Artesanato>? Artesanato { get; set; }

        [Required(ErrorMessage = "É necessario o email do cliente")]
        public string Email_User { get; set; }

    }

}