using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbDatosVenta = new HashSet<TbDatosVenta>();
            TbSoporteClientes = new HashSet<TbSoporteCliente>();
            TbSoportes = new HashSet<TbSoporte>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string CorreoCliente { get; set; } = null!;
        public string PersonaContacto { get; set; } = null!;
        public string DireccionCliente { get; set; } = null!;
        public string TelefonoCliente { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<TbDatosVenta> TbDatosVenta { get; set; }
        public virtual ICollection<TbSoporteCliente> TbSoporteClientes { get; set; }
        public virtual ICollection<TbSoporte> TbSoportes { get; set; }
    }
}
