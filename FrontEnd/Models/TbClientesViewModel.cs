using System.ComponentModel.DataAnnotations;


namespace FrontEnd.Models
{
    public class TbClientesViewModel
    {
        [Key]
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el nombre del Cliente")]
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio ingresar el correo del Cliente")]
        [Display(Name = "Correo")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CorreoCliente { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio ingresar un contacto")]
        [Display(Name = "Contacto")]
        public string PersonaContacto { get; set; } = null!;


        [Required(ErrorMessage = "Es obligatorio ingresar la dirección del Cliente")]
        [Display(Name = "Dirección")]
        public string DireccionCliente { get; set; } = null!;

        [Required(ErrorMessage = "DEbe registrar un número de teléfono")]
        [Display(Name = "Teléfono")]
        [StringLength(8, ErrorMessage = "El teléfono no puede tener más de 8 dígitos")]
        public string TelefonoCliente { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
