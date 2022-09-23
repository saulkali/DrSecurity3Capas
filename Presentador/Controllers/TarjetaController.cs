using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentador.Utils;
using Negocio;
using Entidades;

namespace Presentador.Controllers
{
    [ValidarUsuario]
    public class TarjetaController : Controller
    {

        NTarjeta nTarjetas = new NTarjeta();

        public ActionResult Index()
        {
            ViewBag.usuario = Session["usuario"] as Usuario;
            return View(nTarjetas.ObtenerTarjetas());
        }

        public ActionResult Details(int id)
        {

            return View(nTarjetas.ObtenerTarjetaPorId(id));
        }

        public ActionResult Edit(int id)
        {
            ViewBag.usuario = Session["usuario"] as Usuario;
            return View(nTarjetas.ObtenerTarjetaPorId(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Tarjeta tarjeta)
        {
            try
            {
                if(nTarjetas.EditarTarjeta(id,tarjeta))
                    return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            ViewBag.usuario = Session["usuario"] as Usuario;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tarjeta tarjeta)
        {
            bool esValido = nTarjetas.CrearTarjeta(tarjeta);
            if (esValido)
                return RedirectToAction("Index", "Tarjeta");
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(nTarjetas.ObtenerTarjetaPorId(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                if(nTarjetas.EliminarTarjeta(id))
                    return RedirectToAction("Index");
                return View();
            }
            catch
            {
                return View();
            }
        }


    }
}