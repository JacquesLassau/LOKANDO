using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;

namespace LoKando.DAL
{
    public class VeiculoDAL
    {
        public Conexao Conexao { get; set; }

        public VeiculoDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarVeiculo(Veiculo veiculo){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarVeiculoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCCODLCDLOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@VCTPLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCMARCALOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCMODELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCPLACALOK", SqlDbType.VarChar, 7);
                comandoDML.Parameters.Add("@VCRNVLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCCOMBLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCCORLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCVLRDIA", SqlDbType.Decimal);
                comandoDML.Parameters.Add("@VCAPOLICELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@VCCODLCDLOK"].Value = veiculo.CodigoLocadorVeiculo;
                comandoDML.Parameters["@VCTPLOK"].Value = veiculo.TipoVeiculo;
                comandoDML.Parameters["@VCMARCALOK"].Value = veiculo.MarcaVeiculo;
                comandoDML.Parameters["@VCMODELOK"].Value = veiculo.ModeloVeiculo;
                comandoDML.Parameters["@VCPLACALOK"].Value = veiculo.PlacaVeiculo;
                comandoDML.Parameters["@VCRNVLOK"].Value = veiculo.RenavamVeiculo;
                comandoDML.Parameters["@VCCOMBLOK"].Value = veiculo.CombustivelVeiculo;
                comandoDML.Parameters["@VCCORLOK"].Value = veiculo.CorVeiculo;
                comandoDML.Parameters["@VCVLRDIA"].Value = veiculo.ValorDiaVeiculo;
                comandoDML.Parameters["@VCAPOLICELOK"].Value = veiculo.ApoliceVeiculo;
                comandoDML.Parameters["@VCSITLOK"].Value = veiculo.SituacaoVeiculo;                

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void AlterarVeiculo(Veiculo veiculo){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarVeiculoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCIDLOK", SqlDbType.Int);                
                comandoDML.Parameters.Add("@VCCOMBLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCCORLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCVLRDIA", SqlDbType.Decimal);
                comandoDML.Parameters.Add("@VCAPOLICELOK", SqlDbType.VarChar, 100);

                comandoDML.Parameters["@VCIDLOK"].Value = veiculo.CodigoVeiculo;                
                comandoDML.Parameters["@VCCOMBLOK"].Value = veiculo.CombustivelVeiculo;
                comandoDML.Parameters["@VCCORLOK"].Value = veiculo.CorVeiculo;
                comandoDML.Parameters["@VCVLRDIA"].Value = veiculo.ValorDiaVeiculo;
                comandoDML.Parameters["@VCAPOLICELOK"].Value = veiculo.ApoliceVeiculo;                

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void SituacaoVeiculo(Veiculo veiculo){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_SituacaoVeiculoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCIDLOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@VCSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@VCIDLOK"].Value = veiculo.CodigoVeiculo;
                comandoDML.Parameters["@VCSITLOK"].Value = veiculo.SituacaoVeiculo;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

    }    
}