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
        public string LogadouroLocador { get; set; }
        public string CidadeLocador { get; set; }
        public string EstadoLocador { get; set; }
        public string CepLocador { get; set; }
        public char SituacaoLocador { get; set; }        
        public DateTime HoraRegistroLocador { get; }
    }
}