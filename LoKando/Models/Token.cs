using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Token
    {
        public string TokenUsuario { get; set; }
        public DateTime DataTokenGerado { get; }
        public string OrigemSisToken { get; set; }
        public string DestinoSisToken { get; set; }
        public DateTime DataTokenUtilizado { get; set; }
        public int UsadoPeloUsuario { get; set; }
        public string RetornoToken { get; set; }
        public DateTime ValidadeToken { get; set; }

    }
}