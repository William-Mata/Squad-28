using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public string Email  { get; set; }

        public string Senha  { get; set; }


        [ForeignKey("Cliente")]
        public int? Id_Cliente { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("Contato")]
        public int? Id_Contato { get; set; }
        public virtual Contato? Contato { get; set; }

        [ForeignKey("TriboParceira")]
        public int? Id_TriboParceira { get; set; }
        public virtual TriboParceira? TriboParceira { get; set; }

        [ForeignKey("Pacote")]
        public int? Id_Pacote { get; set; }
        public virtual Pacote? Pacote { get; set; }


    }
}
