using System.ComponentModel.DataAnnotations;

namespace frossi.Models
{
    public class Users
    {
        [Key]
        public int IdUser {  get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(30)]
        public string Nombre {  get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
       // [MaxLength(30)]
        [MinLength(4)]
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}
