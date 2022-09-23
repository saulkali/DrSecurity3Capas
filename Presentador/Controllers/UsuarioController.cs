using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Presentador.Utils;
using Presentador.Utils;
using Entidades;

namespace Presentador.Controllers
{
    [ValidarUsuario]
    public class UsuarioController : Controller
    {
        NUsuario nUsuario = new NUsuario();
  
        public ActionResult Index()
        {
            return View(nUsuario.ObtenerUsuarios());
        }

        public ActionResult Details(int id)
        {
            return View(nUsuario.ObtenerUsuarioPorId(id));
        }

        public ActionResult Edit(int id)
        {
            return View(nUsuario.ObtenerUsuarioPorId(id));
        }

   
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
       
                if(nUsuario.EditarUsuario(id,usuario))
                    return RedirectToAction("Index","Tarjeta");
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(nUsuario.ObtenerUsuarioPorId(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
             
                if(nUsuario.EliminarUsuario(id))
                    return RedirectToAction("Index","Login");
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
