using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class TbEmpleadoViewModel
    {

        [Key]
        [Display(Name = "Id Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "{0} es requerida")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "{0} debe tener mas de nueve carateres")]
        [RegularExpression("([0-9]+)")]
        public string Cedula { get; set; } = null!;

        public string? Foto { get; set; }

        [Required(ErrorMessage = "Es obligatorio agregar el nombre")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el apellido")]
        [Display(Name = "Primer Apellido")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        public string Apellido1 { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el apellido")]
        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        public string Apellido2 { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el teléfono")]
        [Display(Name = "Teléfono Empleado")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho números")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,11}$", ErrorMessage = "Ingresa un teléfono válido")]
        public string TelefonoEmpleado { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el correo")]
        [Display(Name = "Correo Empleado")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string CorreoEmpleado { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar la dirección")]
        [Display(Name = "Dirección")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} debe tener mas de cinco caracteres")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar la contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [PasswordPropertyText(true)]
        [StringLength(500, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho caracteres")]
        public string Contrasena { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el nombre del contacto")]
        [Display(Name = "Nombre Contacto")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        public string NombreContacto { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el teléfono")]
        [Display(Name = "Teléfono Contacto")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho números")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,11}$", ErrorMessage = "Ingresa un teléfono válido")]
        public string TelefonoContacto { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdRol { get; set; }
        public IEnumerable<TbRolViewModel> Roles { get; set; }
        //public List<TbRolViewModel> Roles { get; set; }
        public TbRolViewModel TbRol { get; set; }
        
    }
}
