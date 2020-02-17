using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;
using System.Collections.Generic;
using System;

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
                comandoDML.Parameters.Add("@VCCORLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCCOMBLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCPLACALOK", SqlDbType.VarChar, 7);
                comandoDML.Parameters.Add("@VCRNVLOK", SqlDbType.VarChar, 100);               
                comandoDML.Parameters.Add("@VCVLRDIA", SqlDbType.Decimal);                
                comandoDML.Parameters.Add("@VCSITLOK", SqlDbType.Char, 1);

                comandoDML.Parameters["@VCCODLCDLOK"].Value = veiculo.CodigoLocadorVeiculo;
                comandoDML.Parameters["@VCTPLOK"].Value = veiculo.TipoVeiculo;
                comandoDML.Parameters["@VCMARCALOK"].Value = veiculo.MarcaVeiculo;
                comandoDML.Parameters["@VCMODELOK"].Value = veiculo.ModeloVeiculo;
                comandoDML.Parameters["@VCCORLOK"].Value = veiculo.CorVeiculo;
                comandoDML.Parameters["@VCCOMBLOK"].Value = veiculo.CombustivelVeiculo;
                comandoDML.Parameters["@VCPLACALOK"].Value = veiculo.PlacaVeiculo;
                comandoDML.Parameters["@VCRNVLOK"].Value = veiculo.RenavamVeiculo;                
                comandoDML.Parameters["@VCVLRDIA"].Value = veiculo.ValorDiaVeiculo;                
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

                comandoDML.Parameters["@VCIDLOK"].Value = veiculo.CodigoVeiculo;                
                comandoDML.Parameters["@VCCOMBLOK"].Value = veiculo.CombustivelVeiculo;
                comandoDML.Parameters["@VCCORLOK"].Value = veiculo.CorVeiculo;
                comandoDML.Parameters["@VCVLRDIA"].Value = veiculo.ValorDiaVeiculo;
                               

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Veiculo SelecionarVeiculoPlaca(string placaVeiculo)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Veiculo veiculo = new Veiculo();
                veiculo.PlacaVeiculo = placaVeiculo;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarVeiculoPlacaV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCPLACALOK", SqlDbType.VarChar, 7);
                comandoDML.Parameters["@VCPLACALOK"].Value = veiculo.PlacaVeiculo;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarPlacaVeiculo = dr.HasRows;

                if (consultarPlacaVeiculo == false)
                {
                    veiculo.PlacaVeiculo = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idVeiculo = Convert.ToInt32(dr["VCIDLOK"]);
                        string idLocadorVeiculo = Convert.ToString(dr["VCCODLCDLOK"]);
                        string tipoVeiculo = Convert.ToString(dr["VCTPLOK"]);
                        string marcaVeiculo = Convert.ToString(dr["VCMARCALOK"]);
                        string modeloVeiculo = Convert.ToString(dr["VCMODELOK"]);
                        string plcVeiculo = Convert.ToString(dr["VCPLACALOK"]);
                        string renavamVeiculo = Convert.ToString(dr["VCRNVLOK"]);
                        string combustivelVeiculo = Convert.ToString(dr["VCCOMBLOK"]);                        
                        string corVeiculo = Convert.ToString(dr["VCCORLOK"]);
                        string vlrDiaVeiculo = Convert.ToString(dr["VCVLRDIA"]);
                        string situacaoVeiculo = Convert.ToString(dr["VCSITLOK"]);
                        string ultimaAtualizaoVeiculo = Convert.ToString(dr["VCHRREGLOK"]);

                        veiculo = new Veiculo(idVeiculo, Convert.ToInt32(idLocadorVeiculo), tipoVeiculo, marcaVeiculo, modeloVeiculo, plcVeiculo, renavamVeiculo, combustivelVeiculo, corVeiculo, Convert.ToDecimal(vlrDiaVeiculo), Convert.ToChar(situacaoVeiculo), ultimaAtualizaoVeiculo);
                    }
                }

                conexao.Close();
                return veiculo;
            }
        }

        public void ExcluirVeiculo(Veiculo veiculo){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_SituacaoVeiculoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCIDLOK", SqlDbType.Int);                

                comandoDML.Parameters["@VCIDLOK"].Value = veiculo.CodigoVeiculo;                

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

    }    
}