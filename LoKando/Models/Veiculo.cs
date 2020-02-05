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
        public string ApoliceVeiculo { get; set; }
        public char SituacaoVeiculo { get; set; }
        public DateTime HoraRegistroVeiculo { get; }
    }
}