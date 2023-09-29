namespace BackEnd.Models
{
    public class TbArticuloModel
    {
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
        public int Idproveedor { get; set; }
        public bool Activo { get; set; }
    }
}
