using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class TbArticulosViewModel
    {
        [Key]
        [Display(Name = "Id Artículo")]
        public int IdArticulo { get; set; }


        [Required(ErrorMessage = "Es obligatorio agregar el nombre del artículo")]
        [Display(Name = "Artículo")]
        public string NombreArticulo { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar la descripción ")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar la cantidad de articulos")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Es obligatorio agregar el precio")]
        [Display(Name = "Costo")]
        [Range(0.01, 10000000.00, ErrorMessage = "El precio debe ser mayor a cero")]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(12, 2)")]
        public decimal CostoArticulo { get; set; }


        [Required(ErrorMessage = "Es obligatorio indicar su punto de reorden")]
        [Display(Name = "Reorden")]
        public int PuntoReorden { get; set; }

  
        [Display(Name = "Placa")]
        public string? NumPlaca { get; set; }


        [Required(ErrorMessage = "Es obligatorio agregar el número de parte")]
        [Display(Name = "N° Parte")]
        public string NumParte { get; set; } = null!;


        [Display(Name = "Serial")]
        public string? NumSerie { get; set; }


        [Required(ErrorMessage = "Es obligatorio indicar la vida util del artículo")]
        [Display(Name = "Utilidad")]
        [DataType(DataType.Date)]
        public DateTime VidaUtil { get; set; }

        [Required(ErrorMessage = "Es obligatorio agregar la fecha de vencimiento de garantía")]
        [Display(Name = "Fin Garantía")]
        [DataType(DataType.Date)]
        public DateTime FechaFinGarantia { get; set; }
        public bool Activo { get; set; }

        [Required(ErrorMessage = "Es obligatorio seleccionar un proveedor")]
        [Display(Name = "Proveedor")]
        public int Idproveedor { get; set; }
        public IEnumerable<TbProveedorViewModel> Proveedores { get; set; }
        public TbProveedorViewModel TbProveedor { get; set; }
    }
}
