namespace BackEnd.Models
{
    public class TbSoporteModel
    {
        public int IdSoporte { get; set; }
        public string DescripcionSoporte { get; set; } = null!;
        public DateTime FechaAgendada { get; set; }
        public DateTime? FechaCierreSoporte { get; set; }
        public string Estatus { get; set; } = null!;
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTipo { get; set; }

    }
}
