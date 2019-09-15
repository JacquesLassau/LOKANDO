using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class AtendenteControllerModel
    {
        public List<Atendente> Atendente { get; set; }
                
        public AtendenteControllerModel()
        {
            this.Atendente = new List<Atendente>();
        }
    }
}