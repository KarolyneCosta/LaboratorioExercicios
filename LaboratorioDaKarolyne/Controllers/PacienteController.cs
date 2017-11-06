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
        public ActionResult Novo(Paciente objPaciente)
        {
           Paciente paciente = new Paciente().Save();
           return RedirectToAction("Listar");
        }

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