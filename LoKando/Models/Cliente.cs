using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public int CodigoUsuarioCliente { get; set; }
        public string NomeCliente { get; set; }
        public string HabilitacaoCliente { get; set; }
        public string CpfCliente { get; set; }        
        public string RgCliente { get; set; }
        public DateTime NascimentoCliente { get; set; }
        public string NascimentoClienteStr { get; }
        public string EmailCliente { get; set; }
        public string TelefoneCliente { get; set; }        
        public string EnderecoCliente { get; set; }
        public string CidadeCliente { get; set; }
        public string EstadoCliente { get; set; }
        public string CepCliente { get; set; }
        public char SituacaoCliente { get; set; }
        public string HoraRegistroCliente { get; }    
        
        public Cliente() { }

        public Cliente(int codigoCliente)
        {
            this.CodigoCliente = codigoCliente; 
        }

        public Cliente(string emailCliente)
        {
            this.EmailCliente = emailCliente;
        }

        public Cliente(string nomeCliente, string habilitacaoCliente, string cpfCliente, string rgCliente, DateTime nascimentoCliente, string emailCliente, string telefoneCliente, string enderecoCliente, string cidadeCliente, string estadoCliente, string cepCliente, char situacaoCliente)
        {
            DateTime nascimentoClienteJson = nascimentoCliente;
            this.NascimentoClienteStr = Convert.ToDateTime(nascimentoClienteJson).ToString("yyyy-MM-dd");

            this.NomeCliente = nomeCliente;
            this.HabilitacaoCliente = habilitacaoCliente;
            this.CpfCliente = cpfCliente;
            this.RgCliente = rgCliente;
            this.NascimentoCliente = nascimentoCliente;
            this.EmailCliente = emailCliente;
            this.TelefoneCliente = telefoneCliente;
            this.EnderecoCliente = enderecoCliente;
            this.CidadeCliente = cidadeCliente;
            this.EstadoCliente = estadoCliente;
            this.CepCliente = cepCliente;
            this.SituacaoCliente = situacaoCliente;
        }

        public Cliente(int codigoCliente, string nomeCliente, string habilitacaoCliente, string cpfCliente, string rgCliente, DateTime nascimentoCliente, string emailCliente, string telefoneCliente, string enderecoCliente, string cidadeCliente, string estadoCliente, string cepCliente, string horaRegistroCliente)
        {
            this.CodigoCliente = codigoCliente;
            this.NomeCliente = nomeCliente;
            this.HabilitacaoCliente = habilitacaoCliente;
            this.CpfCliente = cpfCliente;
            this.RgCliente = rgCliente;
            this.NascimentoCliente = nascimentoCliente;
            this.EmailCliente = emailCliente;
            this.TelefoneCliente = telefoneCliente;
            this.EnderecoCliente = enderecoCliente;
            this.CidadeCliente = cidadeCliente;
            this.EstadoCliente = estadoCliente;
            this.CepCliente = cepCliente;
            this.HoraRegistroCliente = horaRegistroCliente;
        }

        public Cliente(int codigoCliente, string nomeCliente, string habilitacaoCliente, string cpfCliente, string rgCliente, DateTime nascimentoCliente, string emailCliente, string telefoneCliente, string enderecoCliente, string cidadeCliente, string estadoCliente, string cepCliente, char situacaoCliente, string horaRegistroCliente)
        {
            DateTime nascimentoClienteJson = nascimentoCliente;
            this.NascimentoClienteStr = Convert.ToDateTime(nascimentoClienteJson).ToString("yyyy-MM-dd");

            this.CodigoCliente = codigoCliente;
            this.NomeCliente = nomeCliente;
            this.HabilitacaoCliente = habilitacaoCliente;
            this.CpfCliente = cpfCliente;
            this.RgCliente = rgCliente;
            this.NascimentoCliente = nascimentoCliente;
            this.EmailCliente = emailCliente;
            this.TelefoneCliente = telefoneCliente;
            this.EnderecoCliente = enderecoCliente;
            this.CidadeCliente = cidadeCliente;
            this.EstadoCliente = estadoCliente;
            this.CepCliente = cepCliente;
            this.SituacaoCliente = situacaoCliente;
            this.HoraRegistroCliente = horaRegistroCliente;
        }

        public Cliente(int codigoCliente, string nomeCliente, string rgCliente, DateTime nascimentoCliente, string telefoneCliente, string enderecoCliente, string cidadeCliente, string estadoCliente, string cepCliente, char situacaoCliente)
        {
            this.CodigoCliente = codigoCliente;
            this.NomeCliente = nomeCliente;          
            this.RgCliente = rgCliente;
            this.NascimentoCliente = nascimentoCliente;           
            this.TelefoneCliente = telefoneCliente;
            this.EnderecoCliente = enderecoCliente;
            this.CidadeCliente = cidadeCliente;
            this.EstadoCliente = estadoCliente;
            this.CepCliente = cepCliente;
            this.SituacaoCliente = situacaoCliente;
        }
    }
}