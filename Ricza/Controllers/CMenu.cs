using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

    }
}
