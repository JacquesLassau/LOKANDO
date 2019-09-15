using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Orcamento
    {
        public int CodigoOrcamento { get; set; } 
        public int CodigoClienteOrcamento { get; set; }
        public string TelefoneClienteOrcamento { get; set; }
        public string CpfClienteOrcamento { get; set; }
        public DateTime NascimentoClienteOrcamento { get; set; }
        public int CodigoVeiculoOrcamento { get; set; }
        public int CodigoLocadorOrcamento { get; set; }
        public DateTime DataInicioLocacao { get; set; }
        public DateTime DataFimLocacao { get; set; }
        public string LocalRetirada { get; set; }
        public string LocalDevolucao { get; set; }
        public decimal ValorTotalOrcamento { get; set; }
        public string SituacaoOrcamento { get; set; }
        public DateTime HoraRegistroOrcamento { get; set; }
    }
}