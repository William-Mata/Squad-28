using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{

    [Table("Imagem")]
    public class Imagem
    {

        [Key]
        public int IdImg { get; set; }
     
        public string Nome { get; set; }
        public byte[] Dados { get; set; }
        public string ContentType { get; set; }

    }
}