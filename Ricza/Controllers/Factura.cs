using Microsoft.AspNetCore.Mvc;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class Factura : Controller
    {
        // GET: Pedido

        public IActionResult Buscar()
        {
            DocMark cot = documento("ibuscar", "Buscar");

            return View(cot);
        }

        public ActionResult ibuscar(int noDoc)
        {
            DocMark cot = documento("Buscar", "Nueva Busqueda");

            if (noDoc == 1234)
            {
                cot.codigo = "C0021";
                cot.nombre = "Ludin López";
                cot.direccion = "zona 9";
                cot.nit = "80708226";
                cot.fecha = "26/09/2023";


                return View("Buscar", cot);
            }
            else
            {
                return RedirectToAction("Buscar", "Factura");
            }


        }


        public DocMark documento(string metodo, string accion)
        {
            return new DocMark
            {
                metodo = metodo,
                controlador = "Factura",
                accion = accion,
                titulo = "Factura Deudores"
            };
        }
    }
}
