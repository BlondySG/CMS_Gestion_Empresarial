using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbSoporteViewModel
    {
        [Key]
        [Display(Name = "Id Soporte")]
        public int IdSoporte { get; set; }

        [Display(Name = "Descripcion soporte")]
        [Required(ErrorMessage = "Es obligatorio ingresar la descripcion del soporte")]
        public string DescripcionSoporte { get; set; } = null!;

        [Display(Name = "Fecha Agendada")]
        [Required(ErrorMessage = "Es obligatorio ingresar la fecha agendada del soporte")]
        [DataType(DataType.Date)]
        public DateTime FechaAgendada { get; set; }

        [Display(Name = "Fecha Cierre Soporte")]
        [DataType(DataType.Date)]
        public DateTime? FechaCierreSoporte { get; set; }

        [Required(ErrorMessage = "Es obligatorio ingresar el estatus del soporte")]
        [Display(Name = "Estatus")]
        public string Estatus { get; set; } = null!;

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdCliente { get; set; }
        public IEnumerable<TbClientesViewModel> Clientes { get; set; }
        public TbClientesViewModel TbCliente { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdEmpleado { get; set; }
        public List<TbEmpleadoViewModel> Empleados { get; set; }
        public TbEmpleadoViewModel TbEmpleado { get; set; }

        [Display(Name = "Tipo Soporte")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdTipo { get; set; }
        public List<TbTipoViewModel> Tipos { get; set; }
        public TbTipoViewModel TbTipo { get; set; }
    }
}
