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
        [HttpGet]
        public ActionResult Listar()
        {
            ViewBag.Planos = new SelectList(new PlanoSaude().BuscarTodos(), "IdPlanoSaude", "Nome");            
            return View();
        }
        [HttpPost]
        public ActionResult Listar(int plano)
        {            
            IList<Paciente> pacientes = new Paciente().GetPlano(plano);
            return PartialView("_ListarPacientes", pacientes);
        }
        [HttpPost]
        public ActionResult Listar(string nomeBusca)
        {
            IList<Paciente> pacientes = new Paciente().GetByName(nomeBusca);
            return PartialView("_ListarPacientes", pacientes);
        }
        [HttpGet]
        public ActionResult Novo()
        {
            ViewBag.Planos = new SelectList(new PlanoSaude().BuscarTodos(), "IdPlanoSaude", "Nome");
            return View();
        }
        //[HttpPost]
        //public ActionResult Novo(Paciente objPaciente)
        //{
        //    Paciente paciente = new Paciente().Save();
        //    return RedirectToAction("Listar");
        //}
        //[HttpGet]
        //public ActionResult Editar()
        //{
        //    ViewBag.Planos = new SelectList(new PlanoSaude().BuscarTodos, "IdPlanoSaude", "Nome");
        //    return View();
        //}
    }
}