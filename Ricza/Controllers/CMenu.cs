using Microsoft.AspNetCore.Mvc;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class CMenu : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Cotizacion()
        {
            var coti = new MCotizacion();
            coti.codigo = "C0021";
            coti.nombre = "Ludin López";
            coti.direccion = "zona 9";
            coti.nit = "80708226";
            coti.fecha = "26/09/2023";
            return View(coti);
        }
        public IActionResult Pedido()
        {
            return View();
        }
        public IActionResult Factura()
        {
            return View();
        }
        public IActionResult SN()
        {
            return View();
        }
        public IActionResult Articulo()
        {
            return View();
        }


    }
}
