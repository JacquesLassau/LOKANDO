using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Pedido
    {
        public int CodigoPedido { get; set; }
        public int CodigoClientePedido { get; set; }
        public string NomeClientePedido { get; set; }
        public string HabilitacaoClientePedido { get; set; }
        public string CpfClientePedido { get; set; }
        public int CodigoLocadorPedido { get; set; }        
        public string NomeFantasiaLocadorPedido { get; set; }
        public int CodigoVeiculoPedido { get; }
        public string PlacaVeiculoPedido { get; set; }
        public int NumeroOrcamentoPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public char SituacaoPedido { get; set; }
        public DateTime HoraRegistroPedido { get; }

    }
}