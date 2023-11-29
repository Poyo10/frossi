using System.ComponentModel.DataAnnotations;

namespace frossi.Models
{
    public class TiposExamenes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(30)]
        public string Nombre { get; set; }

    }
}
