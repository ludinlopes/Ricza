﻿using Microsoft.AspNetCore.Mvc;

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
