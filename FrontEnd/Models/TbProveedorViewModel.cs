using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbProveedorViewModel
    {
        [Key]
        [Display(Name = "Id Proveedor")]
        public int IdProveedor { get; set; }

        [Display(Name = "Nombre Proveedor")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "{0} debe tener mas de tres carateres")]
        [DataType(DataType.Text)]
        public string NombreProveedor { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "{0} debe tener mas de diez carateres")]
        [EmailAddress (ErrorMessage = "{0} debe ser un correo válido")]
        [DataType(DataType.EmailAddress)]
        public string CorreoProveedor { get; set; } = null!;

        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} debe tener mas de tres carateres")]
        [DataType(DataType.Text)]
        public string NombreContacto { get; set; } = null!;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} debe tener mas de tres carateres")]
        [DataType(DataType.Text)]
        public string DireccionProveedor { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "{0} debe tener mas de seis carateres")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoProveedor { get; set; } = null!;

        [Display(Name = "Productos")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "{0} debe tener mas de tres carateres")]
        [DataType(DataType.Text)]
        public string ProductoProveedor { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

    }
}
