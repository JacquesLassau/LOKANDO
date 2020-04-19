using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.ControllerModel
{
    public class LoginAutenticadorControllerModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool ManterConectador { get; set; }
    }
}