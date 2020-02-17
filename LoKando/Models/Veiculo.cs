using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Veiculo
    {
        public int CodigoVeiculo { get; set; }
        public int CodigoLocadorVeiculo { get; set; }
        public string TipoVeiculo { get; set; }
        public string MarcaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public string RenavamVeiculo { get; set; }
        public string CombustivelVeiculo { get; set; }
        public string CorVeiculo { get; set; }
        public decimal ValorDiaVeiculo { get; set; }
        public readonly string ValorDiaVeiculoStrEntrada;        
        public char SituacaoVeiculo { get; set; }
        public string HoraRegistroVeiculo { get; }

        public Veiculo() { }

        public Veiculo(int codigoVeiculo, int codigoLocadorVeiculo, string tipoVeiculo, string marcaVeiculo, string modeloVeiculo, string placaVeiculo, string renavamVeiculo, string combustivelVeiculo, string corVeiculo, decimal valorDiaVeiculo, char situacaoVeiculo, string ultimaAtualizaoVeiculo)
        {
            this.ValorDiaVeiculoStrEntrada = Convert.ToString(valorDiaVeiculo).Replace(',', '.');

            this.CodigoVeiculo = codigoVeiculo;
            this.CodigoLocadorVeiculo = codigoLocadorVeiculo;
            this.TipoVeiculo = tipoVeiculo;
            this.MarcaVeiculo = marcaVeiculo;
            this.ModeloVeiculo = modeloVeiculo;
            this.PlacaVeiculo = placaVeiculo;
            this.RenavamVeiculo = renavamVeiculo;
            this.CombustivelVeiculo = combustivelVeiculo;
            this.CorVeiculo = corVeiculo;
            this.ValorDiaVeiculo = valorDiaVeiculo;
            this.SituacaoVeiculo = situacaoVeiculo;
            this.HoraRegistroVeiculo = ultimaAtualizaoVeiculo;
        }

        public Veiculo(int codigoLocadorVeiculo, string tipoVeiculo, string marcaVeiculo, string modeloVeiculo, string placaVeiculo, string renavamVeiculo, string combustivelVeiculo, string corVeiculo, decimal valorDiaVeiculo, char situacaoVeiculo, string ultimaAtualizaoVeiculo)
        {
            this.ValorDiaVeiculoStrEntrada = Convert.ToString(valorDiaVeiculo).Replace(',', '.');
                        
            this.CodigoLocadorVeiculo = codigoLocadorVeiculo;
            this.TipoVeiculo = tipoVeiculo;
            this.MarcaVeiculo = marcaVeiculo;
            this.ModeloVeiculo = modeloVeiculo;
            this.PlacaVeiculo = placaVeiculo;
            this.RenavamVeiculo = renavamVeiculo;
            this.CombustivelVeiculo = combustivelVeiculo;
            this.CorVeiculo = corVeiculo;
            this.ValorDiaVeiculo = valorDiaVeiculo;
            this.SituacaoVeiculo = situacaoVeiculo;
            this.HoraRegistroVeiculo = ultimaAtualizaoVeiculo;
        }

        public Veiculo(int codigoLocadorVeiculo, string tipoVeiculo, string marcaVeiculo, string modeloVeiculo, string placaVeiculo, string renavamVeiculo, string combustivelVeiculo, string corVeiculo, decimal valorDiaVeiculo, char situacaoVeiculo)
        {
            this.ValorDiaVeiculoStrEntrada = Convert.ToString(valorDiaVeiculo).Replace(',', '.');

            this.CodigoLocadorVeiculo = codigoLocadorVeiculo;
            this.TipoVeiculo = tipoVeiculo;
            this.MarcaVeiculo = marcaVeiculo;
            this.ModeloVeiculo = modeloVeiculo;
            this.PlacaVeiculo = placaVeiculo;
            this.RenavamVeiculo = renavamVeiculo;
            this.CombustivelVeiculo = combustivelVeiculo;
            this.CorVeiculo = corVeiculo;
            this.ValorDiaVeiculo = valorDiaVeiculo;
            this.SituacaoVeiculo = situacaoVeiculo;            
        }
    }
}