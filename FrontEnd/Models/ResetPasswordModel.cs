using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ResetPasswordModel
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} es requerida")]
        [StringLength(14, ErrorMessage = "La {0} debe tener entre {2} y un maximo de {1} caracteres ", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
