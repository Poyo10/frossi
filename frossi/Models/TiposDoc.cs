using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frossi.Models
{
    public class TiposDoc
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "El Id es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(4)]
        public string Nombre { get; set; }

        [MaxLength(32)]
        public string Descri { get; set; }
    }
       
}
