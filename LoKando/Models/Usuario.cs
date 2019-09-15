using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Usuario
    {
        public int CodigoUsuario { get; set;}
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public char SituacaoUsuario { get; set; }

        public Usuario() { }

        public Usuario(char situacaoUsuario)
        {
            this.SituacaoUsuario = situacaoUsuario;
        }

        public Usuario(string emailUsuario)
        {
            this.EmailUsuario = emailUsuario;
        }

        public Usuario(int codigoUsuario, string emailUsuario, string senhaUsuario, char situacaoUsuario)
        {
            this.CodigoUsuario = codigoUsuario;
            this.EmailUsuario = emailUsuario;
            this.SenhaUsuario = senhaUsuario;
            this.SituacaoUsuario = situacaoUsuario;
        }

        public Usuario(string emailUsuario, string senhaUsuario, char situacaoUsuario)
        {
            this.EmailUsuario = emailUsuario;
            this.SenhaUsuario = senhaUsuario;
            this.SituacaoUsuario = situacaoUsuario;
        }
    }
}