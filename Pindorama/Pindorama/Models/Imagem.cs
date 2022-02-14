using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pindorama.Models
{

    [Table("Imagem")]
    public class Imagem
    {
        [Key]
        public int IdImg { get; set; }     
        public string Nome { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }
        public virtual Pacote Pacote { get; set; }
        public virtual Artesanato Artesanato { get; set; }
    }
}