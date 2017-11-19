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
    public class PacienteRepository
    {
        public IList<Paciente> BuscaPorPlano(int plano)
        {  
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente Where planoDeSaudeID=@id";
            comando.Parameters.AddWithValue("@id", plano);

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);
            
            IList<Paciente> pacientes = new List<Paciente>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Paciente objPaciente = new Paciente();
                    objPaciente.IdPaciente = Convert.ToInt32(dr["pacienteId"]);
                    objPaciente.Nome = (string)dr["nome"];
                    objPaciente.DataNascimento = Convert.ToDateTime(dr["dtnascimento"]);
                    objPaciente.EnumTipoConveniado = (TipoConveniado)dr["tipoConveniado"];
                    objPaciente.ObjCidade = Cidade.FindById(Convert.ToInt32(dr["cidadeID"]));
                    objPaciente.ObjPlanoSaude = PlanoSaude.FindById(Convert.ToInt32(dr["cidadeId"]));
                    pacientes.Add(objPaciente);
                }
            }
            else
            {
                pacientes = null;
            }
            return pacientes;
        }

        //internal Paciente Save()
        //{
        //    throw new NotImplementedException();
        //}

        public IList<Paciente> BuscaPorNome(string nomeBusca)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * FROM Paciente Where nome Like @nome";
            comando.Parameters.AddWithValue("@nome", "%" +nomeBusca+ "%");

            Conexao con = new Conexao();
            SqlDataReader dr = Conexao.ExecutarSelect(comando);
            IList<Paciente> pacientes = new List<Paciente>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Paciente objPaciente = new Paciente();
                    objPaciente.Nome = (string)dr["nome"];
                    objPaciente.DataNascimento = Convert.ToDateTime(dr["dtnascimento"]);
                    objPaciente.EnumTipoConveniado = (TipoConveniado)dr["tipoConveniado"];
                    objPaciente.ObjCidade.IdCidade = Convert.ToInt32(dr["cidadeID"]);
                    objPaciente.ObjPlanoSaude.IdPlanoSaude = Convert.ToInt32(dr["cidadeId"]);
                    pacientes.Add(objPaciente);
                }
            }
            else
            {
                pacientes = null;
            }
            return pacientes;
        }
    }
}