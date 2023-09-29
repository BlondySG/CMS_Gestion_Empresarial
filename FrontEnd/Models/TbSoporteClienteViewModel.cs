using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class TbSoporteClienteViewModel
    {


        [Key]
        [Display(Name = "Id SoporteCliente")]
        [ForeignKey("SoporteID")]
        public int IdSoporteCliente { get; set; }

        [Required(ErrorMessage = "Es obligatorio agregar tipo de ID de Soporte")]
        [Display(Name = "ID de Soporte")]
        public int IdSoporte { get; set; }
        public IEnumerable<TbSoporteViewModel> Soporte { get; set; }
        public TbSoporteViewModel TbSoporte { get; set; }



        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdCliente { get; set; }
        public IEnumerable<TbClientesViewModel> Clientes { get; set; }
        public TbClientesViewModel TbClientes { get; set; }

    }
}
