using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaboratorioDaKarolyne.Models;
using System.Data.SqlClient;
using System.Data;
using LaboratorioDaKarolyne.Repository.DAO;

namespace LaboratorioDaKarolyne.Repository
{
    public class CidadeRepository
    {
        public IList<Cidade> SelecionarTodas()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From Cidades";
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<Cidade> cidades = new List<Cidade>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Cidade c = new Cidade();
                    c.IdCidade = (int)dr["cidadeId"];
                    c.Nome = (string)dr["nome"];
                    c.EnumEstado = (Estado)Enum.Parse(typeof(Estado), (string)dr["estado"]);

                    cidades.Add(c);
                }
            }
            else
            {
                cidades = null;
            }
            return cidades;
        }
    }
}