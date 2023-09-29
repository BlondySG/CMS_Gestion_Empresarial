namespace BackEnd.Models
{
    public class TbProveedorModel
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string CorreoProveedor { get; set; } = null!;
        public string NombreContacto { get; set; } = null!;
        public string DireccionProveedor { get; set; } = null!;
        public string TelefonoProveedor { get; set; } = null!;
        public string ProductoProveedor { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
