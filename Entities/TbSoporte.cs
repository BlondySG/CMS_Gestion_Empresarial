﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbSoporte
    {
        public TbSoporte()
        {
            TbEmpleadoSoportes = new HashSet<TbEmpleadoSoporte>();
            TbSoporteClientes = new HashSet<TbSoporteCliente>();
        }

        public int IdSoporte { get; set; }
        public string DescripcionSoporte { get; set; } = null!;
        public DateTime FechaAgendada { get; set; }
        public DateTime? FechaCierreSoporte { get; set; }
        public string Estatus { get; set; } = null!;
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTipo { get; set; }

        public virtual TbCliente IdClienteNavigation { get; set; } = null!;
        public virtual TbEmpleado IdEmpleadoNavigation { get; set; } = null!;
        public virtual TbTipo IdTipoNavigation { get; set; } = null!;
        public virtual ICollection<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; }
        public virtual ICollection<TbSoporteCliente> TbSoporteClientes { get; set; }
    }
}
