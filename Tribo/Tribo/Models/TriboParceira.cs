using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Tribo")]
    public class TriboParceira
    {

        [Key]
        public int IdTribo { get; set; }
        
        [Required(ErrorMessage = "Informe o e-mail.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Informe o nome da tribo.")]
        public string NomeTribo { get; set; }

        [Required(ErrorMessage = "Informe uma descrição.")]
        public string Descricao { get; set; }


    }
}
