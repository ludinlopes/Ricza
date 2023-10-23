using Ricza.Controllers;

namespace Ricza.Models
{
    public class MArticulo
    {
        public String? ItemCode { get; set; }
        public String? Marca { get; set; }
        public String? Modelo { get; set; }
        public String? ItemName { get; set; }
        public String? UserText { get; set; }
        public int? OnHand { get; set; }
        public MBodega? Cantidad { get; set; }
        public double? Precio { get; set; }
        public string? U_TipoA2 { get; set; }
        public string? PicturName { get; set; }

        public string Metodo { get; set; }
        public string Controlador { get; set; }
    }
}
