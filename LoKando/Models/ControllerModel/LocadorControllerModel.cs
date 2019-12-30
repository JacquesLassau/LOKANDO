using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class LocadorControllerModel
    {
        public List<Locador> Locador { get; set; }

        public LocadorControllerModel()
        {
            this.Locador = new List<Locador>();
        }
    }
}