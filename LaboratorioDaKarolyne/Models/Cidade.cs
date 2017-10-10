using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class Cidade
    {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public Estado EnumEstado { get; set; }
    }
}