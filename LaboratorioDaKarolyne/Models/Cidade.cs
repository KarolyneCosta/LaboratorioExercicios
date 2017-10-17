using LaboratorioDaKarolyne.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }

        [DisplayName("Estado")]
        public Estado EnumEstado { get; set; }

        public IList<Cidade> GetAll()
        {
            return new CidadeRepository().SelecionarTodas();
        }
    }
}