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
       [HttpGet]
        public ActionResult Novo()
        {
            return View();
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

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            return View(Cidade.FindById(id));
        }
        [HttpPost]
        public ActionResult Excluir(Cidade objCidade)
        {
            objCidade.Deletar(objCidade);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            return View(Cidade.FindById(id));
        }
        [HttpPost]
        public ActionResult Editar(Cidade objCidade)
        {
            objCidade.Save();
            return RedirectToAction("Index");
        }

        //PartialView
        public ActionResult Listar()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Listar(Estado estado)
        {
            IList<Cidade> cidades = new Cidade().BuscarCidade(estado);
            return PartialView("_ListarCidade", cidades);
        }

        [HttpPost]
        public ActionResult ListarCidadePorEstado(Estado estado)
        {
            IList<Cidade> cidades = new Cidade().BuscarCidade(estado);
            return PartialView("_ListarCidadePorEstado", cidades);
        }
    }
}