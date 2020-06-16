using System;
using LoKando.Models;
using LoKando.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoKando.Models.ControllerModel;
using System.Security.Permissions;

namespace LoKando.Controllers
{
    public class AreaRestritaController : Controller
    {
        // GET: AreaRestrita
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]         
        public ActionResult LoginAR(string txtEmailUsuario, string txtSenhaUsuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Usuario usuario = usuarioDAL.VerificarUsuario(txtEmailUsuario, txtSenhaUsuario);

            if ((usuario.EmailUsuario == txtEmailUsuario) && (usuario.SenhaUsuario == txtSenhaUsuario))
            {
                return RedirectToAction("Index", "Inicio");                
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult LogoutAR()
        {
            return RedirectToAction("Login", "AreaRestrita");
        }
    }
}