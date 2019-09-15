using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ViewModel
{
    public class ClienteModel
    {
        public List<Cliente> Cliente { get; set; }

        public ClienteModel()
        {
            this.Cliente = new List<Cliente>();
        }
    }
}