using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Models
{
    public class ExamesDoAtendimento
    {
        public int IdExamesDoAtendimento { get; set; }
        public DateTime DataExame { get; set; }
        public string Status { get; set; }

        public Exame ObjExame { get; set; }
        public Atendimento ObjAtendimento { get; set; }

        //Relacionamento de Composição utilizando o método construtor
        public ExamesDoAtendimento(Atendimento atendimento)
        {
            ObjAtendimento = atendimento;
        }

    }
}