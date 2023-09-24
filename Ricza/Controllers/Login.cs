using Microsoft.AspNetCore.Mvc;
using Ricza.Models;


namespace Ricza.Controllers
{
    public class Login : Controller
    {
        MLogin usuario = new MLogin();
        
        public IActionResult VLogin()
        {
            return View();
        }
        public ActionResult Inicio(MLogin user)
        {
            usuario.usuario = "Ludin";
            usuario.contraseña = "1234";
            if (usuario.usuario==user.usuario && usuario.contraseña == user.contraseña)
            {
                return RedirectToAction("Menu", "CMenu");
            }
            else
            {
                return View("Vlogin", "Login");
            }


        }
    }
}
