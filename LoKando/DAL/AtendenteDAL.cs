using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;
using System.Collections.Generic;
using System;

namespace LoKando.DAL
{
    public class AtendenteDAL
    {
        public Conexao Conexao { get; set; }

        public AtendenteDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarAtendente(Atendente atendente)
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarAtendenteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@ATNOMELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@ATEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@ATSITATLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@ATNOMELOK"].Value = atendente.NomeAtendente;
                comandoDML.Parameters["@ATEMAILLOK"].Value = atendente.EmailAtendente;
                comandoDML.Parameters["@ATSITATLOK"].Value = atendente.SituacaoAtendente;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void AlterarAtendente(Atendente atendente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarAtendenteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@ATIDATLOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@ATNOMELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@ATSITATLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@ATIDATLOK"].Value = atendente.CodigoUsuarioAtendente;
                comandoDML.Parameters["@ATNOMELOK"].Value = atendente.NomeAtendente;
                comandoDML.Parameters["@ATSITATLOK"].Value = atendente.SituacaoAtendente;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public List<Atendente> ListarAtendente()
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                List<Atendente> atendente = new List<Atendente>();

                SqlCommand comandoDML = new SqlCommand("SP_ListarAtendenteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comandoDML.ExecuteReader();

                while (dr.Read())
                {
                    int idAtendente = Convert.ToInt32(dr["ATIDATLOK"]);
                    string nomeAtendente = Convert.ToString(dr["ATNOMELOK"]);
                    string emailAtendente = Convert.ToString(dr["ATEMAILLOK"]);
                    string ultimaAtualizacaoAtendente = Convert.ToString(dr["ATHRREG"]);

                    atendente.Add(new Atendente(idAtendente, nomeAtendente, emailAtendente, ultimaAtualizacaoAtendente));
                }
                conexao.Close();
                return atendente;
            }
        }

        public Atendente SelecionarAtendenteId(int codigoAtendente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Atendente atendente = new Atendente(codigoAtendente);

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarAtendenteIdV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@ATIDATLOK", SqlDbType.Int);
                comandoDML.Parameters["@ATIDATLOK"].Value = atendente.CodigoAtendente;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarCodigoAtendente = dr.HasRows;

                if (consultarCodigoAtendente == false)
                {
                    atendente.CodigoAtendente = 0;
                }                   
                else
                {
                    while (dr.Read())
                    {
                        int idAtendente = Convert.ToInt32(dr["ATIDATLOK"]);
                        string nomeAtendente = Convert.ToString(dr["ATNOMELOK"]);
                        string emailAtendente = Convert.ToString(dr["ATEMAILLOK"]);
                        string situacaoAtendente = Convert.ToString(dr["ATSITATLOK"]);
                        string ultimaAtualizacaoAtendente = Convert.ToString(dr["ATHRREG"]);

                        atendente = new Atendente(idAtendente, nomeAtendente, emailAtendente, Convert.ToChar(situacaoAtendente), ultimaAtualizacaoAtendente);
                    }
                }

                conexao.Close();
                return atendente;
            }
        }

        public Atendente SelecionarAtendenteEmail(string buscaEmailAtendente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Atendente atendente = new Atendente(buscaEmailAtendente);

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarAtendenteEmailV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@ATEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@ATEMAILLOK"].Value = buscaEmailAtendente;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarEmailAtendente = dr.HasRows;

                if (consultarEmailAtendente == false)
                {
                    atendente.EmailAtendente = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idAtendente = Convert.ToInt32(dr["ATIDATLOK"]);
                        string nomeAtendente = Convert.ToString(dr["ATNOMELOK"]);
                        string emailAtendente = Convert.ToString(dr["ATEMAILLOK"]);
                        string situacaoAtendente = Convert.ToString(dr["ATSITATLOK"]);
                        string ultimaAtualizacaoAtendente = Convert.ToString(dr["ATHRREG"]);

                        atendente = new Atendente(idAtendente, nomeAtendente, emailAtendente, Convert.ToChar(situacaoAtendente), ultimaAtualizacaoAtendente);
                    }
                }

                conexao.Close();
                return atendente;
            }
        }

        public void ExcluirAtendente(Atendente atendente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_ExcluirAtendenteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@ATIDATLOK", SqlDbType.Int);
                comandoDML.Parameters["@ATIDATLOK"].Value = atendente.CodigoUsuarioAtendente;                

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}