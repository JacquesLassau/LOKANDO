using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class Atendente
    {
        public int CodigoAtendente { get; set; }
        public int CodigoUsuarioAtendente { get; set; }
        public string NomeAtendente { get; set; }
        public string EmailAtendente { get; set; }
        public char SituacaoAtendente { get; set; }
        public string HoraRegistroAtendente { get; }
        public readonly char TipoUsuarioAtendente = 'A';

        public Atendente(List<Atendente> list) { }

        public Atendente (Atendente atendente) { }

        public Atendente(int codigoAtendente)
        {
            this.CodigoAtendente = codigoAtendente;
        }

        public Atendente(string emailAtendente)
        {
            this.EmailAtendente = emailAtendente;
        }

        public Atendente(string nomeAtendente, string emailAtendente, char situacaoAtendente)
        {
            this.NomeAtendente = nomeAtendente;
            this.EmailAtendente = emailAtendente;            
            this.SituacaoAtendente = situacaoAtendente;


        }

        public Atendente(string nomeAtendente, string emailAtendente, char situacaoAtendente, string horaRegistroAtendente)
        {
            this.NomeAtendente = nomeAtendente;
            this.EmailAtendente = emailAtendente;
            this.SituacaoAtendente = situacaoAtendente;
            this.HoraRegistroAtendente = horaRegistroAtendente;
        }

        public Atendente(int codigoAtendente, string nomeAtendente, string emailAtendente, string horaRegistroAtendente)
        {
            this.CodigoAtendente = codigoAtendente;
            this.NomeAtendente = nomeAtendente;
            this.EmailAtendente = emailAtendente;
            this.HoraRegistroAtendente = horaRegistroAtendente;
        }

        public Atendente(int codigoAtendente, string nomeAtendente, string emailAtendente, char situacaoAtendente, string horaRegistroAtendente)
        {
            this.CodigoAtendente = codigoAtendente;
            this.NomeAtendente = nomeAtendente;
            this.EmailAtendente = emailAtendente;
            this.SituacaoAtendente = situacaoAtendente;
            this.HoraRegistroAtendente = horaRegistroAtendente;
        }

        public Atendente(int codigoUsuarioAtendente, string nomeAtendente, char situacaoAtendente)
        {
            this.CodigoUsuarioAtendente = codigoUsuarioAtendente;
            this.NomeAtendente = nomeAtendente;            
            this.SituacaoAtendente = situacaoAtendente;
        }

        public Atendente(string nomeAtendente, char situacaoAtendente)
        {
            this.NomeAtendente = nomeAtendente;
            this.SituacaoAtendente = situacaoAtendente;
        }

        public Atendente(char situacaoAtendente)
        {
            this.SituacaoAtendente = situacaoAtendente;
        }

    }
}