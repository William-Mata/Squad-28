using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string tipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe seu nome completo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe sua idade.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe seu CPF.")]
        public string CPF { get; set; }
        public string Origem { get; set; }

        [ForeignKey("Pacote")]
        public int Id_Pacote { get; set; }
        public virtual Pacote Pacote { get; set; }

    }

}