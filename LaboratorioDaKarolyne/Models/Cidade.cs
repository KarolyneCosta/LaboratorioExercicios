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

        public void Save()
        {
            //new CidadeRepository().Salvar();
            CidadeRepository cidadeRep = new CidadeRepository();
            if (IdCidade == 0)
            {
                cidadeRep.Salvar(this);
            }
            else
            {
                cidadeRep.Alterar(this);
            }
        }

        public Cidade FindById(int id)
        {
            CidadeRepository objCidadeRep = new CidadeRepository();
            Cidade objCidade = new Cidade();
            objCidade = objCidadeRep.BuscarPorID(id);
            return objCidade;
        }

        public void Deletar(Cidade c)
        {
            CidadeRepository objCidadeRep = new CidadeRepository();
            objCidadeRep.Deletar(c);
        }

        public IList<Cidade> BuscarCidade(Estado estado)
        {
            CidadeRepository cidadeRepository = new CidadeRepository();
            return cidadeRepository.BuscaCidade(estado);            
        }
    }
}