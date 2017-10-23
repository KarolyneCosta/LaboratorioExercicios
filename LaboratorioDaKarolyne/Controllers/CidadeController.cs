using LaboratorioDaKarolyne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioDaKarolyne.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult Index()
        {
            IList<Cidade> listaDeCidades = new Cidade().GetAll();
            return View(listaDeCidades);
        }

        public ActionResult Novo()
        {
            Cidade c = new Cidade();
            return View(c);
        }

        [HttpPost]
        public ActionResult Novo(Cidade c)
        {
            if (ModelState.IsValid)
            {
                c.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(c);
            }
        }

        public ActionResult Excluir(int id)
        {
            Cidade objCidade = new Cidade().FindById(id);
            return View(objCidade);
        }

        [HttpPost]
        public ActionResult Excluir(Cidade objCidade)
        {
            objCidade.Deletar(objCidade.IdCidade);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade objCidade = new Cidade().FindById(id);
            return View(objCidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidade objCidade)
        {
            objCidade.Save();
            return RedirectToAction("Index");
        }
    }
}