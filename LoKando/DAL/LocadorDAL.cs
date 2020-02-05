using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;
using System.Collections.Generic;
using System;

namespace LoKando.DAL
{
    public class LocadorDAL
    {
        public Conexao Conexao { get; set; }

        public LocadorDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarLocador(Locador locador){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;
                                
                comandoDML.Parameters.Add("@LCEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCRZSLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCFANTLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCPFPJLOK", SqlDbType.VarChar, 18);                
                comandoDML.Parameters.Add("@LCNMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCLOGLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCCIDLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCUFLOK", SqlDbType.VarChar, 2);
                comandoDML.Parameters.Add("@LCCEPLOK", SqlDbType.VarChar, 10);
                comandoDML.Parameters.Add("@LCSITLOK", SqlDbType.Char, 1);
                                
                comandoDML.Parameters["@LCEMAILLOK"].Value = locador.EmailLocador;
                comandoDML.Parameters["@LCRZSLOK"].Value = locador.RazaoSocialLocador;
                comandoDML.Parameters["@LCFANTLOK"].Value = locador.NomeFantasiaLocador;
                comandoDML.Parameters["@LCPFPJLOK"].Value = locador.CpfCnpjLocador;
                comandoDML.Parameters["@LCNMLOK"].Value = locador.TelefoneLocador;
                comandoDML.Parameters["@LCLOGLOK"].Value = locador.EnderecoLocador;
                comandoDML.Parameters["@LCCIDLOK"].Value = locador.CidadeLocador;
                comandoDML.Parameters["@LCUFLOK"].Value = locador.EstadoLocador;
                comandoDML.Parameters["@LCCEPLOK"].Value = locador.CepLocador;
                comandoDML.Parameters["@LCSITLOK"].Value = locador.SituacaoLocador;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void AlterarLocador(Locador locador){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCIDLOCLOK", SqlDbType.Int);                
                comandoDML.Parameters.Add("@LCRZSLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCFANTLOK", SqlDbType.VarChar, 100);                
                comandoDML.Parameters.Add("@LCNMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCLOGLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCCIDLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCUFLOK", SqlDbType.VarChar, 2);
                comandoDML.Parameters.Add("@LCCEPLOK", SqlDbType.VarChar, 10);
                comandoDML.Parameters.Add("@LCSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@LCIDLOCLOK"].Value = locador.CodigoLocador;                
                comandoDML.Parameters["@LCRZSLOK"].Value = locador.RazaoSocialLocador;
                comandoDML.Parameters["@LCFANTLOK"].Value = locador.NomeFantasiaLocador;                
                comandoDML.Parameters["@LCNMLOK"].Value = locador.TelefoneLocador;
                comandoDML.Parameters["@LCLOGLOK"].Value = locador.EnderecoLocador;
                comandoDML.Parameters["@LCCIDLOK"].Value = locador.CidadeLocador;
                comandoDML.Parameters["@LCUFLOK"].Value = locador.EstadoLocador;
                comandoDML.Parameters["@LCCEPLOK"].Value = locador.CepLocador;
                comandoDML.Parameters["@LCSITLOK"].Value = locador.SituacaoLocador;

                comandoDML.ExecuteNonQuery();
                conexao.Close();               
            }
        }

        public List<Locador> ListarLocador()
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                List<Locador> locador = new List<Locador>();

                SqlCommand comandoDML = new SqlCommand("SP_ListarLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comandoDML.ExecuteReader();

                while (dr.Read())
                {
                    int idLocador = Convert.ToInt32(dr["LCIDLOCLOK"]);
                    string mlLocador = Convert.ToString(dr["LCEMAILLOK"]);
                    string razaoScLocador = Convert.ToString(dr["LCRZSLOK"]);
                    string fantasiaLocador = Convert.ToString(dr["LCFANTLOK"]);
                    string documentoLocador = Convert.ToString(dr["LCPFPJLOK"]);
                    string telefoneLocador = Convert.ToString(dr["LCNMLOK"]);
                    string enderecoLocador = Convert.ToString(dr["LCLOGLOK"]);
                    string cidadeLocador = Convert.ToString(dr["LCCIDLOK"]);
                    string estadoLocador = Convert.ToString(dr["LCUFLOK"]);
                    string cepLocador = Convert.ToString(dr["LCCEPLOK"]);
                    string situacaoLocador = Convert.ToString(dr["LCSITLOK"]);
                    string ultimaAtualizaoLocador = Convert.ToString(dr["LCUHRREG"]);

                    locador.Add(new Locador(idLocador, mlLocador, razaoScLocador, fantasiaLocador, documentoLocador, telefoneLocador, enderecoLocador, cidadeLocador, estadoLocador, cepLocador, Convert.ToChar(situacaoLocador), ultimaAtualizaoLocador));
                }
                conexao.Close();
                return locador;
            }
        }

        public Locador SelecionarLocadorEmail(string emailLocador)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Locador locador = new Locador();
                locador.EmailLocador = emailLocador;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarLocadorEmailV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@LCEMAILLOK"].Value = locador.EmailLocador;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarEmailLocaor = dr.HasRows;

                if (consultarEmailLocaor == false)
                {
                    locador.EmailLocador = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idLocador = Convert.ToInt32(dr["LCIDLOCLOK"]);
                        string mlLocador = Convert.ToString(dr["LCEMAILLOK"]);
                        string razaoScLocador = Convert.ToString(dr["LCRZSLOK"]);
                        string fantasiaLocador = Convert.ToString(dr["LCFANTLOK"]);
                        string documentoLocador = Convert.ToString(dr["LCPFPJLOK"]);
                        string telefoneLocador = Convert.ToString(dr["LCNMLOK"]);
                        string enderecoLocador = Convert.ToString(dr["LCLOGLOK"]);
                        string cidadeLocador = Convert.ToString(dr["LCCIDLOK"]);
                        string estadoLocador = Convert.ToString(dr["LCUFLOK"]);
                        string cepLocador = Convert.ToString(dr["LCCEPLOK"]);
                        string situacaoLocador = Convert.ToString(dr["LCSITLOK"]);
                        string ultimaAtualizaoLocador = Convert.ToString(dr["LCUHRREG"]);

                        locador = new Locador(idLocador, mlLocador, razaoScLocador, fantasiaLocador, documentoLocador, telefoneLocador, enderecoLocador, cidadeLocador, estadoLocador, cepLocador, Convert.ToChar(situacaoLocador), ultimaAtualizaoLocador);
                    }

                }

                conexao.Close();
                return locador;
            }
        }

        public Locador SelecionarLocadorDoc(string docLocador)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Locador locador = new Locador();
                locador.CpfCnpjLocador = docLocador;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarLocadorDocV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCPFPJLOK", SqlDbType.VarChar, 18);
                comandoDML.Parameters["@LCPFPJLOK"].Value = locador.CpfCnpjLocador;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarCpfLocador = dr.HasRows;

                if (consultarCpfLocador == false)
                {
                    locador.CpfCnpjLocador = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idLocador = Convert.ToInt32(dr["LCIDLOCLOK"]);
                        string mlLocador = Convert.ToString(dr["LCEMAILLOK"]);
                        string razaoScLocador = Convert.ToString(dr["LCRZSLOK"]);
                        string fantasiaLocador = Convert.ToString(dr["LCFANTLOK"]);
                        string documentoLocador = Convert.ToString(dr["LCPFPJLOK"]);
                        string telefoneLocador = Convert.ToString(dr["LCNMLOK"]);
                        string enderecoLocador = Convert.ToString(dr["LCLOGLOK"]);
                        string cidadeLocador = Convert.ToString(dr["LCCIDLOK"]);
                        string estadoLocador = Convert.ToString(dr["LCUFLOK"]);
                        string cepLocador = Convert.ToString(dr["LCCEPLOK"]);
                        string situacaoLocador = Convert.ToString(dr["LCSITLOK"]);
                        string ultimaAtualizaoLocador = Convert.ToString(dr["LCUHRREG"]);

                        locador = new Locador(idLocador, mlLocador, razaoScLocador, fantasiaLocador, documentoLocador, telefoneLocador, enderecoLocador, cidadeLocador, estadoLocador, cepLocador, Convert.ToChar(situacaoLocador), ultimaAtualizaoLocador);
                    }
                }

                conexao.Close();
                return locador;
            }
        }

        public Locador SelecionarLocadorId(int codigoLocador)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Locador locador = new Locador();
                locador.CodigoLocador = codigoLocador;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarLocadorIdV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCIDLOCLOK", SqlDbType.Int);
                comandoDML.Parameters["@LCIDLOCLOK"].Value = locador.CodigoLocador;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarIdLocador = dr.HasRows;

                if (consultarIdLocador == false)
                {
                    locador.CodigoLocador = 0;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idLocador = Convert.ToInt32(dr["LCIDLOCLOK"]);
                        string mlLocador = Convert.ToString(dr["LCEMAILLOK"]);
                        string razaoScLocador = Convert.ToString(dr["LCRZSLOK"]);
                        string fantasiaLocador = Convert.ToString(dr["LCFANTLOK"]);
                        string documentoLocador = Convert.ToString(dr["LCPFPJLOK"]);
                        string telefoneLocador = Convert.ToString(dr["LCNMLOK"]);
                        string enderecoLocador = Convert.ToString(dr["LCLOGLOK"]);
                        string cidadeLocador = Convert.ToString(dr["LCCIDLOK"]);
                        string estadoLocador = Convert.ToString(dr["LCUFLOK"]);
                        string cepLocador = Convert.ToString(dr["LCCEPLOK"]);
                        string situacaoLocador = Convert.ToString(dr["LCSITLOK"]);
                        string ultimaAtualizaoLocador = Convert.ToString(dr["LCUHRREG"]);

                        locador = new Locador(idLocador, mlLocador, razaoScLocador, fantasiaLocador, documentoLocador, telefoneLocador, enderecoLocador, cidadeLocador, estadoLocador, cepLocador, Convert.ToChar(situacaoLocador), ultimaAtualizaoLocador);
                    }
                }

                conexao.Close();
                return locador;
            }
        }

        public void ExcluirLocador(Locador locador){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_ExcluirLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCIDLOCLOK", SqlDbType.Int); 
                comandoDML.Parameters["@LCIDLOCLOK"].Value = locador.CodigoLocador;                 

                comandoDML.ExecuteNonQuery();
                conexao.Close();                
            }
        }
    }
}