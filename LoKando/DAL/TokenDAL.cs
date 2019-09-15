using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;

namespace LoKando.DAL
{
    public class TokenDAL
    {
        public Conexao Conexao { get; set; }

        public TokenDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarToken(Token token){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("CadastrarTokenV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@TOKENLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKORIGEMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKDESTINOLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKDTUTILLOK", SqlDbType.DateTime);
                comandoDML.Parameters.Add("@TKUTILUSULOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@TKRTNLOK", SqlDbType.VarChar, 8000);
                comandoDML.Parameters.Add("@TKVALIDLOK", SqlDbType.DateTime);

                comandoDML.Parameters["@TOKENLOK"].Value = token.TokenUsuario;
                comandoDML.Parameters["@TKORIGEMLOK"].Value = token.OrigemSisToken;
                comandoDML.Parameters["@TKDESTINOLOK"].Value = token.DestinoSisToken;
                comandoDML.Parameters["@TKDTUTILLOK"].Value = token.DataTokenUtilizado;
                comandoDML.Parameters["@TKUTILUSULOK"].Value = token.UsadoPeloUsuario;
                comandoDML.Parameters["@TKRTNLOK"].Value = token.RetornoToken;
                comandoDML.Parameters["@TKVALIDLOK"].Value = token.ValidadeToken;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void UsarToken(Token token){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("UsarTokenV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@TOKENLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKORIGEMLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKDESTINOLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@TKDTUTILLOK", SqlDbType.DateTime);
                comandoDML.Parameters.Add("@TKUTILUSULOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@TKRTNLOK", SqlDbType.VarChar, 8000);
                comandoDML.Parameters.Add("@TKVALIDLOK", SqlDbType.DateTime);

                comandoDML.Parameters["@TOKENLOK"].Value = token.TokenUsuario;
                comandoDML.Parameters["@TKORIGEMLOK"].Value = token.OrigemSisToken;
                comandoDML.Parameters["@TKDESTINOLOK"].Value = token.DestinoSisToken;
                comandoDML.Parameters["@TKDTUTILLOK"].Value = token.DataTokenUtilizado;
                comandoDML.Parameters["@TKUTILUSULOK"].Value = token.UsadoPeloUsuario;
                comandoDML.Parameters["@TKRTNLOK"].Value = token.RetornoToken;
                comandoDML.Parameters["@TKVALIDLOK"].Value = token.ValidadeToken;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}