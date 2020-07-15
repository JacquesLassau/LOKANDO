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
    public class UsuarioController : Controller
    {
        public UsuarioControllerModel ConvertToModel(List<Usuario> listaUsuario)
        {
            UsuarioControllerModel usuarioControllerModel = new UsuarioControllerModel();
            if (listaUsuario != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach (var usuario in listaUsuario)
                {
                    usuarioControllerModel.Usuario.Add(usuario);
                }
            }

            return usuarioControllerModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarEmailUsuarioAR(string EmailUsuario, string NovoEmailUsuario)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuario = usuarioDAL.SelecionarUsuarioEmail(EmailUsuario);

                if (usuario == null)
                {
                    TempData[Constantes.MensagemAlerta] = "Email inválido. Tente novamente.";
                    return RedirectToAction("Index", "Inicio");
                }
                                
                usuarioDAL.AlterarEmailUsuario(EmailUsuario, NovoEmailUsuario);
                TempData[Constantes.MensagemAlerta] = "Email alterado com sucesso. Você será redirecionado para o login em segundos.";
                return RedirectToAction("Login", "AreaRestrita");                
            }
            else
            {
                TempData[Constantes.MensagemAlerta] = "Ocorreu um problema com a troca de email. Tente novamente.";
                return RedirectToAction("Index", "Inicio");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenhaUsuarioAR(string EmailUsuario, string SenhaUsuario, string NovaSenhaUsuario)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                UsuarioDAL usuarioDAL = new UsuarioDAL();
                Usuario usuario = usuarioDAL.SelecionarUsuarioEmail(EmailUsuario);

                if (usuario == null)
                {
                    TempData[Constantes.MensagemAlerta] = "Email inválido. Tente novamente.";
                    return RedirectToAction("Index", "Inicio");
                }

                usuarioDAL.AlterarSenhaUsuario(EmailUsuario, SenhaUsuario, NovaSenhaUsuario);
                TempData[Constantes.MensagemAlerta] = "Senha alterada com sucesso. Você será redirecionado para o login em segundos.";
                return RedirectToAction("Login", "AreaRestrita");
            }
            else
            {
                TempData[Constantes.MensagemAlerta] = "Ocorreu um problema com a troca da senha. Tente novamente.";
                return RedirectToAction("Index", "Inicio");
            }
        }
    }
}