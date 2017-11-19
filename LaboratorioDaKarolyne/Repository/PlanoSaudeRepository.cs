using LaboratorioDaKarolyne.Models;
using LaboratorioDaKarolyne.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LaboratorioDaKarolyne.Repository
{
    public class PlanoSaudeRepository
    {
        public IList<PlanoSaude> BuscarPlano()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM PlanoDeSaude";
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            IList<PlanoSaude> planos = new List<PlanoSaude>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    PlanoSaude objPlano = new PlanoSaude();
                    objPlano.IdPlanoSaude = (int)dr["planoDeSaudeID"];
                    objPlano.Nome = (string)dr["descricao"];
                    planos.Add(objPlano);
                }
            }
            else
            {
                planos = null;
            }
            return planos;
        }
        public PlanoSaude BuscaPorId(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM PlanoDeSaude where planoDeSaudeID=@id";

            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                PlanoSaude objPlano = new PlanoSaude();
                objPlano.IdPlanoSaude = Convert.ToInt32(dr["planoDeSaudeID"]);
                objPlano.Nome = (string)dr["descricao"];
                return objPlano;
            }            
            return null;
        }
    }
}