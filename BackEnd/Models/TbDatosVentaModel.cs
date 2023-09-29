namespace BackEnd.Models
{
    public class TbDatosVentaModel
    {
        public int IdVenta { get; set; }
        public string NumFacturaVenta { get; set; } = null!;
        public DateTime? FechaCompra { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal ImpuestoVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdArticulo { get; set; }
        public int IdCliente { get; set; }
    }
}
