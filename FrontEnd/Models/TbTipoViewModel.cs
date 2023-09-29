using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbTipoViewModel
    {
        [Display(Name = "Id Tipo")]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Es obligatorio agregar tipo de soporte")]
        [Display(Name = "Tipo de Soporte")]
        public string NombreSoporte { get; set; } = null!;     //[Display(Name = "Id Rol")]
   

    }
}
