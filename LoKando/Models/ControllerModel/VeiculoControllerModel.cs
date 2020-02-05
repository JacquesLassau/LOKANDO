using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class VeiculoControllerModel
    {
        public List<Veiculo> Veiculo { get; set; }

        public VeiculoControllerModel()
        {
            this.Veiculo = new List<Veiculo>();
        }
    }
}