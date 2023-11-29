using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frossi.Models
{
    public class ExaHechos
    {
        [Key]
        public int Id { get; set; }
        
        public int IdTipoExamen { get; set; }
        
        [ForeignKey("IdTipoExamen")]
        public TiposExamenes TiposExamenes { get; set; }

        public int IdSolicitante { get; set; }
        [ForeignKey("IdSolicitante")]
        public Solicitantes Solicitantes { get; set; }

        public int Correctas { get; set; }
        
        public int Incorrectas { get; set; }
        
        public DateTime FechaInicio { get; set; }
        
        public DateTime FechaFin { get; set; }

    }

}
