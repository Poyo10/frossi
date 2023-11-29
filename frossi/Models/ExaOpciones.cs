using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace frossi.Models
{
    public class ExaOpciones
    {

        [Key]
        public int Id { get; set; }

        public int IdPregunta { get; set; }

        [ForeignKey("IdPregunta")]
        public ExaPreguntas ExaPreguntas { get; set; }

        public int Orden {  get; set; }
        public string TextoOpcion { get; set; }

    }
}
