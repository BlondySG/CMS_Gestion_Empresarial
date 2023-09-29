using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RegisterModel
    {
        [Display(Name = "Nombre Usuario")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(20, ErrorMessage = "El {0} debe tener entre {2} y un maximo de {1} caracteres ", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras y espacios")]
        public string UserName { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} es requerida")]
        [StringLength(14,ErrorMessage = "La {0} debe tener entre {2} y un maximo de {1} caracteres ", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
