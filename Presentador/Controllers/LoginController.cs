using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;


namespace Presentador.Controllers
{
    public class LoginController : Controller
    {
        NLogin nLogin = new NLogin();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string correo = Convert.ToString(form["email"]);
            string contrasena = Convert.ToString(form["password"]);
            Usuario usuario = nLogin.Entrar(correo, contrasena);
            if (usuario != null) {
                Session["usuario"] = usuario;
                return RedirectToAction("Index", "Tarjeta");
            }
            else
            {

                TempData["mensaje"] = "Credenciales Incorrecta";
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index","Login");
        }



    }
}