using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;

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

                SqlCommand comandoDML = new SqlCommand("CadastrarLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;
                                
                comandoDML.Parameters.Add("@LCEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCRZSLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCFANTLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@LCPFPJLOK", SqlDbType.VarChar, 14);                
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
                comandoDML.Parameters["@LCLOGLOK"].Value = locador.LogadouroLocador;
                comandoDML.Parameters["@LCCIDLOK"].Value = locador.CidadeLocador;
                comandoDML.Parameters["@LCUFLOK"].Value = locador.CidadeLocador;
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

                SqlCommand comandoDML = new SqlCommand("AlterarLocadorV1", conexao);
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
                comandoDML.Parameters["@LCLOGLOK"].Value = locador.LogadouroLocador;
                comandoDML.Parameters["@LCCIDLOK"].Value = locador.CidadeLocador;
                comandoDML.Parameters["@LCUFLOK"].Value = locador.CidadeLocador;
                comandoDML.Parameters["@LCCEPLOK"].Value = locador.CepLocador;
                comandoDML.Parameters["@LCSITLOK"].Value = locador.SituacaoLocador;

                comandoDML.ExecuteNonQuery();
                conexao.Close();               
            }
        }

        public void SituacaoLocador(Locador locador){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SituacaoLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@LCIDLOCLOK", SqlDbType.Int);                
                comandoDML.Parameters.Add("@LCSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@LCIDLOCLOK"].Value = locador.CodigoLocador;                
                comandoDML.Parameters["@LCSITLOK"].Value = locador.SituacaoLocador;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}