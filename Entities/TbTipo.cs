using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TbTipo
    {
        public TbTipo()
        {
            TbSoportes = new HashSet<TbSoporte>();
        }

        public int IdTipo { get; set; }
        public string NombreSoporte { get; set; } = null!;

        public virtual ICollection<TbSoporte> TbSoportes { get; set; }
    }
}
