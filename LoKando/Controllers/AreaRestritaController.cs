using System;
using LoKando.Models;
using LoKando.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoKando.Models.ControllerModel;

namespace LoKando.Controllers
{
    public class AreaRestritaController : Controller
    {
        public ActionResult Login()
        {
            string btnClick = Request["btnLogin"];

            if (btnClick == "Login")
            {
                string sessaoEmail = Request["txtEmailUsuario"];
                string sessaoSenha = Request["txtSenhaUsuario"];

                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuario = new Usuario(sessaoEmail, sessaoSenha);

                var login = usuarioDAL.AcessoUsuario(usuario);

                if ((login.EmailUsuario != null) && (login.SenhaUsuario != null))
                {
                    Session["sessaoEmail"] = usuario.EmailUsuario;
                    Session["sessaoId"] = usuario.CodigoUsuario;
                    return RedirectToAction("index", "Inicio");
                }
                else
                {
                    return View();
                }

            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "AreaRestrita");
        }
    }    
}