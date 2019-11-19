using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class ClienteControllerModel
    {
        public List<Cliente> Cliente { get; set; }

        public ClienteControllerModel()
        {
            this.Cliente = new List<Cliente>();
        }
    }
}