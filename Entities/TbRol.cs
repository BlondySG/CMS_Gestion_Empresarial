using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbRol
    {
        public TbRol()
        {
            TbEmpleados = new HashSet<TbEmpleado>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; } = null!;
        public bool Activo { get; set; }

        public virtual ICollection<TbEmpleado> TbEmpleados { get; set; }
    }
}
