using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Ricza.Implement;
using Ricza.Models;

namespace Ricza.Controllers
{
    public class Cotizacion : Controller
    {
        private ImCoti m = new ImCoti();
        
        public IActionResult crear()
        {
            
            MDocument cot = documento("icrear","Crear");
            cot.DocDate = DateTime.Now;
            return View(cot);
        }
        public IActionResult buscar()
        {
            MDocument cot = documento("ibuscar","Buscar");

            return View(cot);
        }

        public IActionResult actualizar()
        {
            return View();
        }

        public ActionResult ibuscar(int noDoc)
        {
            MDocument cot = m.GetDocument(noDoc,"icrear", "crear"); ;


                return View("actualizar",cot);



        }

        public ActionResult icrear() 
        { 
            return RedirectToAction("crear", "Cotizacion");
        }

        public ActionResult iactualizar() 
        {
            return RedirectToAction("crear", "Cotizacion");
        }


        public MDocument documento(string metodo, string accion)
        {
            return new MDocument
            {
                metodo = metodo,
                controlador = "Cotizacion",
                accion = accion,
                titulo = "Cotización"
            };
        }


    }
}
