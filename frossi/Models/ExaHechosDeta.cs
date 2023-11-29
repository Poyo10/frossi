using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frossi.Models
{
    public class ExaHechosDeta
    {
        [Key]
        public int Id { get; set; }

        public int IdExaHecho { get; set; }
        [ForeignKey("IdExaHecho")]
        public ExaHechos ExaHechos { get; set; }

        public int IdExaPreguntas { get; set; }
        [ForeignKey("IdExaPreguntas")]
        public ExaPreguntas ExaPreguntas { get; set; }

        public int Rta {  get; set; }


    }
}
