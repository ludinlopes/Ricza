using Microsoft.AspNetCore.Mvc;
using Ricza.Implement;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class SN : Controller
    {
        public IActionResult Cliente()
        {
            MSocioNegocios mSocio = new MSocioNegocios();
            return View(mSocio);
        }

        public ActionResult GetSn(string Codigo)
        {

            var cons = new ImSN();
            return View("Cliente", cons.Consulta(Codigo));

        }
    }
}
