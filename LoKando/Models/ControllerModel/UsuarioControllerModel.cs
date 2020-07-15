using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class UsuarioControllerModel
    {
        public List<Usuario> Usuario { get; set; }

        public UsuarioControllerModel()
        {
            this.Usuario = new List<Usuario>();
        }
    }
}