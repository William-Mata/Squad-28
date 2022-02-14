using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pindorama.Models
{
    [Table("AldeiaParceira")]
    public class AldeiaParceira
    {

        [Key]
        public int IdAldeia { get; set; }

        [Required(ErrorMessage = "Informe o nome da aldeia.")]
        public string NomeAldeia { get; set; }

        [Required(ErrorMessage = "Informe o estado em que a aldeia se localiza.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a cidade em que a aldeia se localiza.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe um numero de celular para contato com a aldeia.")]
        public string Celular { get; set; }

        public virtual List<Pacote> Pacote { get; set; }

        public virtual List<Artesanato> Artesanato { get; set; }

        [Required(ErrorMessage = "É necessario o email da aldeia.")]
        public string Email_User { get; set; }

    }
}
