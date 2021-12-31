﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tribo.Models
{
    [Table("Pacote")]
    public class Pacote
    {
        [Key]
        public int IdPacote { get; set; }

        [Required(ErrorMessage = "Informe uma descrição.")]
        public string Descricao { get; set; }

        public string Destino { get; set; }

        [Required(ErrorMessage = "Informe o valor do pacote.")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "A data de inicio.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de final.")]
        public DateTime DataFim { get; set; }



        [ForeignKey("Imagem")]
        public int Id_Imagem { get; set; }
        public virtual Imagem Imagem { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Tribo> Tribo { get; set; }

    }
}
