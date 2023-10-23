using Microsoft.AspNetCore.Mvc;
using Ricza.Implement;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class Articulo : Controller
    {

        public IActionResult Buscar(String Codigo)
        {

            ImItem n = new ImItem();
            if (Codigo != null)
            {
                return View(n.GetItem(Codigo));

            }
            else
            {
                MArticulo m = new MArticulo();
                return View(m);
            }

        }


    }
}
