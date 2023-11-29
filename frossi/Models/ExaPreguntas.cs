using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frossi.Models
{
    public class ExaPreguntas
    {
        [Key]
        public int Id { get; set; }

        public int IdTipoExamen { get; set; }

        [ForeignKey("IdTipoExamen")]
        public TiposExamenes TiposExamenes { get; set; }

        public string Texto { get; set; }
        public string PathImagen { get; set; }
        public int RtaCorrecta { get; set; }



    }
}
