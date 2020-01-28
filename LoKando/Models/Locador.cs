using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Locador
    {
        public int CodigoLocador { get; set; }        
        public string EmailLocador { get; set; }
        public string RazaoSocialLocador { get; set; }
        public string NomeFantasiaLocador { get; set; }
        public string CpfCnpjLocador { get; set; }
        public string TelefoneLocador { get; set; }
        public string EnderecoLocador { get; set; }
        public string CidadeLocador { get; set; }
        public string EstadoLocador { get; set; }
        public string CepLocador { get; set; }
        public char SituacaoLocador { get; set; }        
        public string HoraRegistroLocador { get; }

        public Locador() { }

        public Locador(string mlLocador, string razaoScLocador, string fantasiaLocador, string documentoLocador, string telefoneLocador, string enderecoLocador, string cidadeLocador, string estadoLocador, string cepLocador, char situacaoLocador)
        {
            this.EmailLocador = mlLocador;
            this.RazaoSocialLocador = razaoScLocador;
            this.NomeFantasiaLocador = fantasiaLocador;
            this.CpfCnpjLocador = documentoLocador;
            this.TelefoneLocador = telefoneLocador;
            this.EnderecoLocador = enderecoLocador;
            this.CidadeLocador = cidadeLocador;
            this.EstadoLocador = estadoLocador;
            this.CepLocador = cepLocador;
            this.SituacaoLocador = situacaoLocador;
        }

        public Locador(int idLocador, string mlLocador, string razaoScLocador, string fantasiaLocador, string documentoLocador, string telefoneLocador, string enderecoLocador, string cidadeLocador, string estadoLocador, string cepLocador, string ultimaAtualizaoLocador)
        {
            this.CodigoLocador = idLocador;
            this.EmailLocador = mlLocador;
            this.RazaoSocialLocador = razaoScLocador;
            this.NomeFantasiaLocador = fantasiaLocador;
            this.CpfCnpjLocador = documentoLocador;
            this.TelefoneLocador = telefoneLocador;
            this.EnderecoLocador = enderecoLocador;
            this.CidadeLocador = cidadeLocador;
            this.EstadoLocador = estadoLocador;
            this.CepLocador = cepLocador;
            this.HoraRegistroLocador = ultimaAtualizaoLocador;
        }
    }

}