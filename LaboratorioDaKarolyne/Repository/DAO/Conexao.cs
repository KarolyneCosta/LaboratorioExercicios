using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LaboratorioDaKarolyne.Repository.DAO
{
    public class Conexao
    {
        private static SqlConnection Conectar()
        {
            //Para poder ter acesso ao BD
            string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoLaboratorio"].ConnectionString;
            //Conectar o BD
            SqlConnection conexao = new SqlConnection(stringConexao);
            //Abrir o BD
            conexao.Open();

            return conexao;
        }

        public static int ExecutarCrud(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            int id = (int)comando.ExecuteScalar();
            con.Close();

            return id;
            //Toda vez que o comando ExecutarCrud for chamado ele se conectará ao banco para ter acesso as informações do banco, podendo assim executar o update, delete, insert e busca.            
        }

        public static SqlDataReader ExecutarSelect(SqlCommand comando)
        {
            SqlConnection con = Conectar();
            comando.Connection = con;
            SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);

            return dr;
            //É com o SqlDataReader que vamos fazer o select no banco para podermos fazer uma busca
        }
    }
}