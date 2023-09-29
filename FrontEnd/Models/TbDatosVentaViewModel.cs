using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class TbDatosVentaViewModel
    {
        [Key]
        [Display(Name = "Id Venta")]
        public int IdVenta { get; set; }

        [Display(Name = "Número Factura")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} debe tener mas de tres carateres")]
        public string NumFacturaVenta { get; set; } = null!;

        [Display(Name = "Fecha Compra")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime? FechaCompra { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "{0} es requerida")]
        public int Cantidad { get; set; }
        
        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Impuesto")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, 13)]
        [DisplayFormat(DataFormatString = "{0:0.00%}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ImpuestoVenta { get; set; }

        [Display(Name = "Sub Total")]
        [Range(0, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal SubTotalVenta { get; set; }

        [Display(Name = "Total")]
        [Range(0, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalVenta { get; set; }

        [Display(Name = "Fecha Venta")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }

        [Display(Name = "Articulo")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdArticulo { get; set; }
        public List<TbArticulosViewModel> Articulos { get; set; }
        public TbArticulosViewModel TbArticulo { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdCliente { get; set; }
        public IEnumerable<TbClientesViewModel> Clientes { get; set;}
        public TbClientesViewModel TbCliente { get; set; } 
    }
}
