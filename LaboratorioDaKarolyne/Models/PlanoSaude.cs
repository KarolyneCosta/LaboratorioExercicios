using LaboratorioDaKarolyne.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class PlanoSaude
    {
        public int IdPlanoSaude { get; set; }
        public string Nome { get; set; }

        public IList<PlanoSaude> BuscarTodos()
        {            
            return new PlanoSaudeRepository().BuscarPlano();
        }
        public static PlanoSaude FindById(int id)
        {
            return new PlanoSaudeRepository().BuscaPorId(id);
        }
    }
}