using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pindorama.Models
{
    [Table("Artesanato")]
    public class Artesanato
    {
        [Key]
        public int IdArtesanato { get; set; }

        [Required(ErrorMessage = "Informe o Tipo.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe uma descrição.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o valor do Artesanato.")]
        public string Valor { get; set; }


        [ForeignKey("Imagem")]
        public int? Id_Imagem { get; set; }
        public virtual Imagem? Imagem { get; set; }

        [ForeignKey("Cliente")]
        public virtual List<Cliente> Cliente { get; set; }

        [ForeignKey("AldeiaParceira")]
        public virtual AldeiaParceira? Aldeia { get; set; }
      
    }
}
