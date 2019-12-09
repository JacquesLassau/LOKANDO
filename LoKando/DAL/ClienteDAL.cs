using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;
using System.Collections.Generic;
using System;

namespace LoKando.DAL
{
    public class ClienteDAL
    {
        public Conexao Conexao { get; set; }

        public ClienteDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarCliente(Cliente cliente){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarClienteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;
                                
                comandoDML.Parameters.Add("@CLNOMELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLHABILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLCPFLOK", SqlDbType.VarChar, 14);
                comandoDML.Parameters.Add("@CLRGLOK", SqlDbType.VarChar, 20);
                comandoDML.Parameters.Add("@CLNASCLOK", SqlDbType.DateTime);
                comandoDML.Parameters.Add("@CLEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLNMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLLOGLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLCIDLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLUFLOK", SqlDbType.VarChar, 2);
                comandoDML.Parameters.Add("@CLCEPLOK", SqlDbType.VarChar, 9);
                comandoDML.Parameters.Add("@CLSITLOK", SqlDbType.Char, 1);
                                
                comandoDML.Parameters["@CLNOMELOK"].Value = cliente.NomeCliente;
                comandoDML.Parameters["@CLHABILLOK"].Value = cliente.HabilitacaoCliente;
                comandoDML.Parameters["@CLCPFLOK"].Value = cliente.CpfCliente;
                comandoDML.Parameters["@CLRGLOK"].Value = cliente.RgCliente;
                comandoDML.Parameters["@CLNASCLOK"].Value = cliente.NascimentoCliente;
                comandoDML.Parameters["@CLEMAILLOK"].Value = cliente.EmailCliente;
                comandoDML.Parameters["@CLNMLOK"].Value = cliente.TelefoneCliente;
                comandoDML.Parameters["@CLLOGLOK"].Value = cliente.EnderecoCliente;
                comandoDML.Parameters["@CLCIDLOK"].Value = cliente.CidadeCliente;
                comandoDML.Parameters["@CLUFLOK"].Value = cliente.EstadoCliente;
                comandoDML.Parameters["@CLCEPLOK"].Value = cliente.CepCliente;
                comandoDML.Parameters["@CLSITLOK"].Value = cliente.SituacaoCliente;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void AlterarCliente(Cliente cliente){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarClienteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLIDCLLOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@CLNOMELOK", SqlDbType.VarChar, 100);                
                comandoDML.Parameters.Add("@CLRGLOK", SqlDbType.VarChar, 20);
                comandoDML.Parameters.Add("@CLNASCLOK", SqlDbType.DateTime);                
                comandoDML.Parameters.Add("@CLNMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLLOGLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLCIDLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@CLUFLOK", SqlDbType.VarChar, 2);
                comandoDML.Parameters.Add("@CLCEPLOK", SqlDbType.VarChar, 9);
                comandoDML.Parameters.Add("@CLSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@CLIDCLLOK"].Value = cliente.CodigoCliente;
                comandoDML.Parameters["@CLNOMELOK"].Value = cliente.NomeCliente;                
                comandoDML.Parameters["@CLRGLOK"].Value = cliente.RgCliente;
                comandoDML.Parameters["@CLNASCLOK"].Value = cliente.NascimentoCliente;                
                comandoDML.Parameters["@CLNMLOK"].Value = cliente.TelefoneCliente;
                comandoDML.Parameters["@CLLOGLOK"].Value = cliente.EnderecoCliente;
                comandoDML.Parameters["@CLCIDLOK"].Value = cliente.CidadeCliente;
                comandoDML.Parameters["@CLUFLOK"].Value = cliente.EstadoCliente;
                comandoDML.Parameters["@CLCEPLOK"].Value = cliente.CepCliente;
                comandoDML.Parameters["@CLSITLOK"].Value = cliente.SituacaoCliente;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }        

        public List<Cliente> ListarCliente()
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                List<Cliente> cliente = new List<Cliente>();

                SqlCommand comandoDML = new SqlCommand("SP_ListarClienteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comandoDML.ExecuteReader();

                while (dr.Read())
                {
                    int idCliente = Convert.ToInt32(dr["CLIDCLLOK"]);
                    string nomeCliente = Convert.ToString(dr["CLNOMELOK"]);
                    string habilitacaoCliente = Convert.ToString(dr["CLHABILLOK"]);
                    string cpfCliente = Convert.ToString(dr["CLCPFLOK"]);
                    string rgCliente = Convert.ToString(dr["CLRGLOK"]);
                    string nascimentoCliente = Convert.ToString(dr["CLNASCLOK"]);
                    string emailCliente = Convert.ToString(dr["CLEMAILLOK"]);
                    string telefoneCliente = Convert.ToString(dr["CLNMLOK"]);
                    string logadouroCliente = Convert.ToString(dr["CLLOGLOK"]);
                    string cidadeCliente = Convert.ToString(dr["CLCIDLOK"]);
                    string estadoCliente = Convert.ToString(dr["CLUFLOK"]);
                    string cepCliente = Convert.ToString(dr["CLCEPLOK"]);
                    string ultimaAtualizacaoCliente = Convert.ToString(dr["CLHRREG"]);

                    cliente.Add(new Cliente(idCliente, nomeCliente, habilitacaoCliente, cpfCliente, rgCliente, Convert.ToDateTime(nascimentoCliente), emailCliente, telefoneCliente, logadouroCliente, cidadeCliente, estadoCliente, cepCliente, ultimaAtualizacaoCliente));
                }
                conexao.Close();
                return cliente;
            }
        }

        public Cliente SelecionarClienteId(int codigoCliente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Cliente cliente = new Cliente(codigoCliente);

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarClienteIdV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLIDCLLOK", SqlDbType.Int);
                comandoDML.Parameters["@CLIDCLLOK"].Value = cliente.CodigoCliente;                

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarCodigoCliente = dr.HasRows;

                if (consultarCodigoCliente == false)
                {
                    cliente.CodigoCliente = 0;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idCliente = Convert.ToInt32(dr["CLIDCLLOK"]);
                        string nomeCliente = Convert.ToString(dr["CLNOMELOK"]);
                        string habilitacaoCliente = Convert.ToString(dr["CLHABILLOK"]);
                        string cpfCliente = Convert.ToString(dr["CLCPFLOK"]);
                        string rgCliente = Convert.ToString(dr["CLRGLOK"]);
                        DateTime nascimentoCliente = Convert.ToDateTime(dr["CLNASCLOK"]);
                        string emailCliente = Convert.ToString(dr["CLEMAILLOK"]);
                        string telefoneCliente = Convert.ToString(dr["CLNMLOK"]);
                        string logadouroCliente = Convert.ToString(dr["CLLOGLOK"]);
                        string cidadeCliente = Convert.ToString(dr["CLCIDLOK"]);
                        string estadoCliente = Convert.ToString(dr["CLUFLOK"]);
                        string cepCliente = Convert.ToString(dr["CLCEPLOK"]);
                        string situacaoCliente = Convert.ToString(dr["CLSITLOK"]);
                        string ultimaAtualizacaoCliente = Convert.ToString(dr["CLHRREG"]);

                        cliente = new Cliente(idCliente, nomeCliente, habilitacaoCliente, cpfCliente, rgCliente, nascimentoCliente, emailCliente, telefoneCliente, logadouroCliente, cidadeCliente, estadoCliente, cepCliente, Convert.ToChar(situacaoCliente), ultimaAtualizacaoCliente);
                    }
                }

                conexao.Close();
                return cliente;
            }
        }

        public Cliente SelecionarClienteHabilitacao(string habilCliente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Cliente cliente = new Cliente();
                cliente.HabilitacaoCliente = habilCliente;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarClienteHabilitacaoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLHABILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@CLHABILLOK"].Value = cliente.HabilitacaoCliente;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarHabilitacaoCliente = dr.HasRows;

                if (consultarHabilitacaoCliente == false)
                {
                    cliente.HabilitacaoCliente = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idCliente = Convert.ToInt32(dr["CLIDCLLOK"]);
                        string nomeCliente = Convert.ToString(dr["CLNOMELOK"]);
                        string habilitacaoCliente = Convert.ToString(dr["CLHABILLOK"]);
                        string cpfCliente = Convert.ToString(dr["CLCPFLOK"]);
                        string rgCliente = Convert.ToString(dr["CLRGLOK"]);
                        string nascimentoCliente = Convert.ToString(dr["CLNASCLOK"]);
                        string emailCliente = Convert.ToString(dr["CLEMAILLOK"]);
                        string telefoneCliente = Convert.ToString(dr["CLNMLOK"]);
                        string logadouroCliente = Convert.ToString(dr["CLLOGLOK"]);
                        string cidadeCliente = Convert.ToString(dr["CLCIDLOK"]);
                        string estadoCliente = Convert.ToString(dr["CLUFLOK"]);
                        string cepCliente = Convert.ToString(dr["CLCEPLOK"]);
                        string ultimaAtualizacaoCliente = Convert.ToString(dr["CLHRREG"]);

                        cliente = new Cliente(idCliente, nomeCliente, habilitacaoCliente, cpfCliente, rgCliente, Convert.ToDateTime(nascimentoCliente), emailCliente, telefoneCliente, logadouroCliente, cidadeCliente, estadoCliente, cepCliente, ultimaAtualizacaoCliente);
                    }
                }

                conexao.Close();
                return cliente;
            }
        }

        public Cliente SelecionarClienteEmail(string emailCliente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Cliente cliente = new Cliente(emailCliente);

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarClienteEmailV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@CLEMAILLOK"].Value = cliente.EmailCliente;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarEmailCliente = dr.HasRows;

                if (consultarEmailCliente == false)
                {
                    cliente.EmailCliente = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idCliente = Convert.ToInt32(dr["CLIDCLLOK"]);
                        string nomeCliente = Convert.ToString(dr["CLNOMELOK"]);
                        string habilitacaoCliente = Convert.ToString(dr["CLHABILLOK"]);
                        string cpfCliente = Convert.ToString(dr["CLCPFLOK"]);
                        string rgCliente = Convert.ToString(dr["CLRGLOK"]);
                        string nascimentoCliente = Convert.ToString(dr["CLNASCLOK"]);
                        string emlCliente = Convert.ToString(dr["CLEMAILLOK"]);
                        string telefoneCliente = Convert.ToString(dr["CLNMLOK"]);
                        string logadouroCliente = Convert.ToString(dr["CLLOGLOK"]);
                        string cidadeCliente = Convert.ToString(dr["CLCIDLOK"]);
                        string estadoCliente = Convert.ToString(dr["CLUFLOK"]);
                        string cepCliente = Convert.ToString(dr["CLCEPLOK"]);
                        string ultimaAtualizacaoCliente = Convert.ToString(dr["CLHRREG"]);

                        cliente = new Cliente(idCliente, nomeCliente, habilitacaoCliente, cpfCliente, rgCliente, Convert.ToDateTime(nascimentoCliente), emlCliente, telefoneCliente, logadouroCliente, cidadeCliente, estadoCliente, cepCliente, ultimaAtualizacaoCliente);
                    }
                }

                conexao.Close();
                return cliente;
            }
        }

        public Cliente SelecionarClienteCpf(string cpfCliente)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Cliente cliente = new Cliente();
                cliente.CpfCliente = cpfCliente;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarClienteCpfV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLCPFLOK", SqlDbType.VarChar, 14);
                comandoDML.Parameters["@CLCPFLOK"].Value = cliente.CpfCliente;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarCpfCliente = dr.HasRows;

                if (consultarCpfCliente == false)
                {
                    cliente.CpfCliente = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idCliente = Convert.ToInt32(dr["CLIDCLLOK"]);
                        string nomeCliente = Convert.ToString(dr["CLNOMELOK"]);
                        string habilitacaoCliente = Convert.ToString(dr["CLHABILLOK"]);
                        string pfCliente = Convert.ToString(dr["CLCPFLOK"]);
                        string rgCliente = Convert.ToString(dr["CLRGLOK"]);
                        string nascimentoCliente = Convert.ToString(dr["CLNASCLOK"]);
                        string emailCliente = Convert.ToString(dr["CLEMAILLOK"]);
                        string telefoneCliente = Convert.ToString(dr["CLNMLOK"]);
                        string logadouroCliente = Convert.ToString(dr["CLLOGLOK"]);
                        string cidadeCliente = Convert.ToString(dr["CLCIDLOK"]);
                        string estadoCliente = Convert.ToString(dr["CLUFLOK"]);
                        string cepCliente = Convert.ToString(dr["CLCEPLOK"]);
                        string ultimaAtualizacaoCliente = Convert.ToString(dr["CLHRREG"]);

                        cliente = new Cliente(idCliente, nomeCliente, habilitacaoCliente, pfCliente, rgCliente, Convert.ToDateTime(nascimentoCliente), emailCliente, telefoneCliente, logadouroCliente, cidadeCliente, estadoCliente, cepCliente, ultimaAtualizacaoCliente);
                    }
                }

                conexao.Close();
                return cliente;
            }
        }

        public void ExcluirCliente(Cliente cliente)
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_ExcluirClienteV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@CLIDCLLOK", SqlDbType.Int);                
                comandoDML.Parameters["@CLIDCLLOK"].Value = cliente.CodigoCliente;                

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}