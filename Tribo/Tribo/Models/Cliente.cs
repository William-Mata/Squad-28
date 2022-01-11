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
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe um numero de celular para contato com a tribo.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Informe sua idade.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }

        public string? Origem { get; set; }


        [ForeignKey("Pacote")]
        public int? Id_Pacote { get; set; }
        public virtual Pacote? Pacote { get; set; }

        [Required(ErrorMessage = "É necessario o email do cliente")]
        public string Email_User { get; set; }
        public virtual Admin Admin { get; set; }
    }

}