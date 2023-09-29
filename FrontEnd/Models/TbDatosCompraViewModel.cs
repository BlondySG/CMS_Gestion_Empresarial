using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class TbDatosCompraViewModel
    {

        [Key]
        [Display(Name = "Id Compra")]
        public int IdCompra { get; set; }

        [Display(Name = "Número Factura")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} debe tener mas de 1 caracter")]
        [DataType(DataType.Text)]
        public string NumFacturaCompra { get; set; } = null!;

        [Display(Name = "Proveeedor")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdProveedor { get; set; }
        public IEnumerable<TbProveedorViewModel> Proveedores { get; set; }
        public TbProveedorViewModel TbProveedor { get; set; }

        [Display(Name = "Articulo")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdArticulo { get; set; }
        public List<TbArticulosViewModel> Articulos { get; set; }
        public TbArticulosViewModel TbArticulo { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "{0} es requerida")]
        [Range(1, 10000000)]
        public int Cantidad { get; set; }

        [Display(Name = "Precio Unitario")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(1, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PrecioUnitario { get; set; }

        [Display(Name = "Impuesto")]
        [Required(ErrorMessage = "{0} es requerido")]
        [Range(0, 13)]
        [DisplayFormat(DataFormatString = "{0:0.00%}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ImpuestoCompra { get; set; }

        [Display(Name = "Sub Total")]
        [Range(0, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal SubTotalCompra { get; set; }

        [Display(Name = "Total")]
        [Range(0, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalCompra { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }

    }

}
