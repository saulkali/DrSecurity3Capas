using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;


namespace Presentador.Controllers
{
    public class RegistrarController : Controller
    {
        NUsuario nUsuario = new NUsuario();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            string confirContrasena = form["confirmPassword"];


            Usuario usuario = new Usuario
            {
                nombre = form["name"],
                apellidoPaterno = form["firtName"],
                apellidoMaterno = form["lastName"],
                correo = form["email"],
                contrasena = form["password"],
                direccion = form["address"]

            };

            if (confirContrasena != usuario.contrasena)
                return View();
            if(nUsuario.CrearUsuario(usuario))
                return RedirectToAction("Index", "Login");
            return View();
        }

       
    }
}
