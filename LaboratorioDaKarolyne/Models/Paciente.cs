using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public PlanoSaude ObjPlanoSaude { get; set; }
        public TipoConveniado EnumTipoConveniado { get; set; }
        public Cidade ObjCidade { get; set; }
    }
}