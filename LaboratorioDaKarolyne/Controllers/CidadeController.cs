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
    }
}