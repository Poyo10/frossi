using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace frossi.Models
{
    public class Solicitantes
    {
//        [Key]
        public int Id { get; set; }

        public int IdTipoDoc { get; set; }
        [ForeignKey("IdTipoDoc")] 
        public TiposDoc TiposDoc { get; set; } 
   
        [Required]
        [StringLength(12)]
        public string NroDoc { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(50)]
        public string Apellido{ get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        // Otros campos si los hubiera
    }
}
