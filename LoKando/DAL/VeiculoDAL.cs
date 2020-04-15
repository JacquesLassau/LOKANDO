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
                comandoDML.Parameters.Add("@VCANOLOK", SqlDbType.VarChar, 4);
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
                comandoDML.Parameters["@VCANOLOK"].Value = veiculo.AnoVeiculo;
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
                
                comandoDML.Parameters.Add("@VCCODLCDLOK", SqlDbType.Int);
                comandoDML.Parameters.Add("@VCTPLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCMARCALOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCMODELOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCCOMBLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCPLACALOK", SqlDbType.VarChar, 7);
                comandoDML.Parameters.Add("@VCCORLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@VCANOLOK", SqlDbType.VarChar, 4);
                comandoDML.Parameters.Add("@VCVLRDIA", SqlDbType.Decimal);
                comandoDML.Parameters.Add("@VCSITLOK", SqlDbType.Char, 1);
                
                comandoDML.Parameters["@VCCODLCDLOK"].Value = veiculo.CodigoLocadorVeiculo;
                comandoDML.Parameters["@VCTPLOK"].Value = veiculo.TipoVeiculo;
                comandoDML.Parameters["@VCMARCALOK"].Value = veiculo.MarcaVeiculo;
                comandoDML.Parameters["@VCMODELOK"].Value = veiculo.ModeloVeiculo;
                comandoDML.Parameters["@VCCOMBLOK"].Value = veiculo.CombustivelVeiculo;
                comandoDML.Parameters["@VCPLACALOK"].Value = veiculo.PlacaVeiculo;
                comandoDML.Parameters["@VCCORLOK"].Value = veiculo.CorVeiculo;
                comandoDML.Parameters["@VCANOLOK"].Value = veiculo.AnoVeiculo;
                comandoDML.Parameters["@VCVLRDIA"].Value = veiculo.ValorDiaVeiculo;
                comandoDML.Parameters["@VCSITLOK"].Value = veiculo.SituacaoVeiculo;

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
                        string anoVeiculo = Convert.ToString(dr["VCANOLOK"]);
                        string vlrDiaVeiculo = Convert.ToString(dr["VCVLRDIA"]);
                        string situacaoVeiculo = Convert.ToString(dr["VCSITLOK"]);
                        string ultimaAtualizaoVeiculo = Convert.ToString(dr["VCHRREGLOK"]);

                        veiculo = new Veiculo(idVeiculo, Convert.ToInt32(idLocadorVeiculo), tipoVeiculo, marcaVeiculo, modeloVeiculo, plcVeiculo, renavamVeiculo, combustivelVeiculo, corVeiculo, anoVeiculo, Convert.ToDecimal(vlrDiaVeiculo), Convert.ToChar(situacaoVeiculo), ultimaAtualizaoVeiculo);
                    }
                }

                conexao.Close();
                return veiculo;
            }
        }

        public Veiculo SelecionarVeiculoRenavam(string renavamVeiculo)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Veiculo veiculo = new Veiculo();
                veiculo.RenavamVeiculo = renavamVeiculo;

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarVeiculoRenavamV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCRNVLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@VCRNVLOK"].Value = veiculo.RenavamVeiculo;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarRenavamVeiculo = dr.HasRows;

                if (consultarRenavamVeiculo == false)
                {
                    veiculo.RenavamVeiculo = null;
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
                        string rnvVeiculo = Convert.ToString(dr["VCRNVLOK"]);
                        string combustivelVeiculo = Convert.ToString(dr["VCCOMBLOK"]);
                        string corVeiculo = Convert.ToString(dr["VCCORLOK"]);
                        string anoVeiculo = Convert.ToString(dr["VCANOLOK"]);
                        string vlrDiaVeiculo = Convert.ToString(dr["VCVLRDIA"]);
                        string situacaoVeiculo = Convert.ToString(dr["VCSITLOK"]);
                        string ultimaAtualizaoVeiculo = Convert.ToString(dr["VCHRREGLOK"]);

                        veiculo = new Veiculo(idVeiculo, Convert.ToInt32(idLocadorVeiculo), tipoVeiculo, marcaVeiculo, modeloVeiculo, plcVeiculo, rnvVeiculo, combustivelVeiculo, corVeiculo, anoVeiculo, Convert.ToDecimal(vlrDiaVeiculo), Convert.ToChar(situacaoVeiculo), ultimaAtualizaoVeiculo);
                    }
                }

                conexao.Close();
                return veiculo;
            }
        }

        public List<Veiculo> ListarVeiculosLocadorId(int codigoLocador)
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                List<Veiculo> veiculo = new List<Veiculo>();
                Veiculo propriedadeVeiculo = new Veiculo();
                propriedadeVeiculo.CodigoLocadorVeiculo = codigoLocador;

                SqlCommand comandoDML = new SqlCommand("SP_ListarVeiculosLocadorIdV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCCODLCDLOK", SqlDbType.Int);
                comandoDML.Parameters["@VCCODLCDLOK"].Value = propriedadeVeiculo.CodigoLocadorVeiculo;

                SqlDataReader dr = comandoDML.ExecuteReader();

                while (dr.Read())
                {
                    string codigoVeiculo = Convert.ToString(dr["VCIDLOK"]);
                    string codigoLocadorVeiculo = Convert.ToString(dr["VCCODLCDLOK"]);
                    string tipoVeiculo = Convert.ToString(dr["VCTPLOK"]);
                    string marcaVeiculo = Convert.ToString(dr["VCMARCALOK"]);
                    string modeloVeiculo = Convert.ToString(dr["VCMODELOK"]);
                    string placaVeiculo = Convert.ToString(dr["VCPLACALOK"]);
                    string renavamVeiculo = Convert.ToString(dr["VCRNVLOK"]);
                    string combustivelVeiculo = Convert.ToString(dr["VCCOMBLOK"]);
                    string corVeiculo = Convert.ToString(dr["VCCORLOK"]);
                    string anoVeiculo = Convert.ToString(dr["VCANOLOK"]);
                    string valorDiaVeiculo = Convert.ToString(dr["VCVLRDIA"]);
                    string situacaoVeiculo = Convert.ToString(dr["VCSITLOK"]);
                    string ultimaAtualizaoVeiculo = Convert.ToString(dr["VCHRREGLOK"]);

                    veiculo.Add(new Veiculo(Convert.ToInt32(codigoVeiculo), Convert.ToInt32(codigoLocadorVeiculo), tipoVeiculo, marcaVeiculo, modeloVeiculo, placaVeiculo, renavamVeiculo, combustivelVeiculo, corVeiculo, anoVeiculo, Convert.ToDecimal(valorDiaVeiculo), Convert.ToChar(situacaoVeiculo), ultimaAtualizaoVeiculo));
                }
                conexao.Close();
                return veiculo;
            }
        }

        public List<Veiculo> ListarVeiculoLocador()
        {
            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                List<Veiculo> veiculo = new List<Veiculo>();

                SqlCommand comandoDML = new SqlCommand("SP_ListarVeiculoLocadorV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comandoDML.ExecuteReader();

                while (dr.Read())
                {
                    
                    string idLocador = Convert.ToString(dr["LCIDLOCLOK"]);                    
                    string fantasiaLocador = Convert.ToString(dr["LCFANTLOK"]);
                    string tipoVeiculo = Convert.ToString(dr["VCTPLOK"]);
                    string marcaVeiculo = Convert.ToString(dr["VCMARCALOK"]);
                    string modeloVeiculo = Convert.ToString(dr["VCMODELOK"]);
                    string placaVeiculo = Convert.ToString(dr["VCPLACALOK"]);
                    string renavamVeiculo = Convert.ToString(dr["VCRNVLOK"]);
                    string combustivelVeiculo = Convert.ToString(dr["VCCOMBLOK"]);
                    string corVeiculo = Convert.ToString(dr["VCCORLOK"]);
                    string anoVeiculo = Convert.ToString(dr["VCANOLOK"]);
                    string vlrDiaVeiculo = Convert.ToString(dr["VCVLRDIA"]);
                    string situacaoVeiculo = Convert.ToString(dr["VCSITLOK"]);
                    string ultimaAtualizaoVeiculo = Convert.ToString(dr["VCHRREGLOK"]);

                    veiculo.Add(new Veiculo(Convert.ToInt32(idLocador), fantasiaLocador, tipoVeiculo, marcaVeiculo, modeloVeiculo, placaVeiculo, renavamVeiculo, combustivelVeiculo, corVeiculo, anoVeiculo, Convert.ToDecimal(vlrDiaVeiculo), Convert.ToChar(situacaoVeiculo), ultimaAtualizaoVeiculo));
                }
                conexao.Close();
                return veiculo;
            }
        }

        public void ExcluirVeiculo(Veiculo veiculo){

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_ExcluirVeiculoV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@VCPLACALOK", SqlDbType.VarChar, 7);
                comandoDML.Parameters["@VCPLACALOK"].Value = veiculo.PlacaVeiculo;

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

    }    
}