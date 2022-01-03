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
        public string tipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o nome da tribo.")]
        public string NomeTribo { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }


        [ForeignKey("Pacote")]
        public int? Id_Pacote { get; set; }
        public virtual Pacote? Pacote { get; set; }


        public virtual Admin? Admin { get; set; }

    }
}
