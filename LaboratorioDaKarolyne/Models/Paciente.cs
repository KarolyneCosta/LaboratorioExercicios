using LaboratorioDaKarolyne.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        [Display(Name ="Plano de Saúde")]
        public PlanoSaude ObjPlanoSaude { get; set; }
        [Display(Name = "Convênio")]
        public TipoConveniado EnumTipoConveniado { get; set; }
        [Display(Name = "Cidade")]
        public Cidade ObjCidade { get; set; }

        //internal Paciente Save()
        //{
        //    return new PacienteRepository().Save(this);
        //}

        public IList<Paciente> GetPlano(int plano)
        {            
            return new PacienteRepository().BuscaPorPlano(plano);
        }
        public IList<Paciente> GetByName(string nomeBusca)
        {
            return new PacienteRepository().BuscaPorNome(nomeBusca);
        }
    }
}