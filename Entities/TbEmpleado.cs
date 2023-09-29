using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbEmpleado
    {
        public TbEmpleado()
        {
            TbBitacoras = new HashSet<TbBitacora>();
            TbEmpleadoSoportes = new HashSet<TbEmpleadoSoporte>();
            TbSoportes = new HashSet<TbSoporte>();
        }

        public int IdEmpleado { get; set; }
        public string Cedula { get; set; } = null!;
        public byte[]? Foto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string TelefonoEmpleado { get; set; } = null!;
        public string CorreoEmpleado { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string NombreContacto { get; set; } = null!;
        public string TelefonoContacto { get; set; } = null!;
        public bool Activo { get; set; }
        public int IdRol { get; set; }

        public virtual TbRol IdRolNavigation { get; set; } = null!;
        public virtual ICollection<TbBitacora> TbBitacoras { get; set; }
        public virtual ICollection<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; }
        public virtual ICollection<TbSoporte> TbSoportes { get; set; }
    }
}
