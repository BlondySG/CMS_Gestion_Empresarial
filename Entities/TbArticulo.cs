using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbArticulo
    {
        public TbArticulo()
        {
            TbDatosCompras = new HashSet<TbDatosCompra>();
            TbDatosVenta = new HashSet<TbDatosVenta>();
        }

        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal CostoArticulo { get; set; }
        public int PuntoReorden { get; set; }
        public string? NumPlaca { get; set; }
        public string NumParte { get; set; } = null!;
        public string? NumSerie { get; set; }
        public DateTime VidaUtil { get; set; }
        public DateTime FechaFinGarantia { get; set; }
        public bool Activo { get; set; }
        public int Idproveedor { get; set; }

        public virtual TbProveedor? IdProveedorNavigation { get; set; }
        public virtual ICollection<TbDatosCompra> TbDatosCompras { get; set; }
        public virtual ICollection<TbDatosVenta> TbDatosVenta { get; set; }
    }
}
