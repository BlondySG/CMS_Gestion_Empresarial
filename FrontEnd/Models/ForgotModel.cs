using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ForgotModel
    {
        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string Email { get; set; }
    }
}
