using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class Pedido : Controller
    {
        // GET: Pedido
        public IActionResult crear()
        {
            DocMark cot = documento("icrear", "Crear");

            return View(cot);
        }
        public IActionResult buscar()
        {
            DocMark cot = documento("ibuscar", "Buscar");

            return View(cot);
        }

        public IActionResult actualizar()
        {
            return View();
        }

        public ActionResult ibuscar(int noDoc)
        {
            DocMark cot = documento("iactualizar", "Guardar");

            if (noDoc == 1234)
            {
                cot.codigo = "C0021";
                cot.nombre = "Ludin López";
                cot.direccion = "zona 9";
                cot.nit = "80708226";
                cot.fecha = "26/09/2023";


                return View("actualizar", cot);
            }
            else
            {
                return RedirectToAction("buscar", "Pedido");
            }


        }

        public ActionResult icrear()
        {
            return RedirectToAction("crear", "Pedido");
        }

        public ActionResult iactualizar()
        {
            return RedirectToAction("crear", "Pedido");
        }


        public DocMark documento(string metodo, string accion)
        {
            return new DocMark
            {
                metodo = metodo,
                controlador = "Pedido",
                accion = accion,
                titulo = "Pedido de Venta"
            };
        }


    }
}
