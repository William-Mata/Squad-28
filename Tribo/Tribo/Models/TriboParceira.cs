using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("TriboParceira")]
    public class TriboParceira
    {

        [Key]
        public int IdTribo { get; set; }

        [Required(ErrorMessage = "Informe o nome da tribo.")]
        public string NomeTribo { get; set; }

        [Required(ErrorMessage = "Informe o estado em que a tribo se localiza.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a cidade em que a tribo se localiza.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe um numero de celular para contato com a tribo.")]
        public string Celular { get; set; }

        [ForeignKey("Pacote")]
        public int? Id_Pacote { get; set; }
        public virtual Pacote? Pacote { get; set; }

        [Required(ErrorMessage = "É necessario o email da tribo.")]
        public string Email_User { get; set; }
        public virtual Admin? Admin { get; set; }

    }
}
