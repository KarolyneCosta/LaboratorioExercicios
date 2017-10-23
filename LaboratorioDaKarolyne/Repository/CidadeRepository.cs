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
                    //c.EnumEstado = Enum.GetValues(typeof (Estado), (string)dr["estado"]);
                    //c.EnumEstado = (Estado)Enum.Parse(typeof(Estado), (string)dr["estado"]);

                    cidades.Add(c);
                }
            }
            else
            {
                cidades = null;
            }
            return cidades;
        }

        public Cidade BuscarPorID(int id)
        {
            Cidade objCidade = new Cidade();


            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select*From Cidades Where cidadeId=@id";

            comando.Parameters.AddWithValue("@id", id);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);

            if (dr.HasRows)
            {
                dr.Read();
                objCidade.IdCidade = (int)dr["IdCidade"];
                objCidade.Nome = dr["Nome"].ToString();
                //objCidade.EnumEstado = (string)dr["EnumEstado"]; 
            }
            else
            {
                objCidade = null;
            }
            return objCidade;
        }


        public void Deletar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "DELETE Cidades WHERE cidadeId=@id ";

            comando.Parameters.AddWithValue("@id", objCidade.IdCidade);

            Conexao.ExecutarCrud(comando);
        }

        public void Salvar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Cidades (nome, estado) VALUES (@nome, @cidade)";

            comando.Parameters.AddWithValue("@nome", objCidade.Nome);
            comando.Parameters.AddWithValue("@estado", objCidade.EnumEstado);

            Conexao.ExecutarCrud(comando);            
        }

        public void Alterar(Cidade objCidade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = " UPDATE Cidades SET nome=@nome, enumEstado=@enumEstado WHERE cidadeId=@id";

            comando.Parameters.AddWithValue("@nome", objCidade.Nome);
            comando.Parameters.AddWithValue("@enumEstado", objCidade.EnumEstado);
            comando.Parameters.AddWithValue("@id", objCidade.IdCidade);

            Conexao.ExecutarCrud(comando);
        }
    }
}