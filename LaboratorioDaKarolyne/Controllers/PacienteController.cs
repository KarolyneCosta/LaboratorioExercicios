using LaboratorioDaKarolyne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioDaKarolyne.Controllers
{
    public class PacienteController : Controller
    {
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo()
        {
           Paciente paciente = new Paciente().Save();
           return RedirectToAction("Listar");
        }
        // GET: Paciente
        public ActionResult Listar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar1()
        {
            return View();
        }
    }
}