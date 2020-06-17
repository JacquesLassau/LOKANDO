using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models
{
    public class ValidarAdmin
    {
        public static bool UsuarioValido()
        {
            HttpContext contexto = HttpContext.Current;
            if (contexto.Session["sessaoId"] != null)
            {
                return true;                
            }
            else
            {
                return false;
            }
            
        }
    }
}