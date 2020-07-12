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
    public class AtendenteController : Controller
    {
        public AtendenteControllerModel ConvertToModel(List<Atendente> listaAtendente)
        {
            AtendenteControllerModel atendenteControllerModel = new AtendenteControllerModel();
            if(listaAtendente != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach (var atendente in listaAtendente)
                {
                    atendenteControllerModel.Atendente.Add(atendente);
                }
            }

            return atendenteControllerModel;
        }

        [HttpGet]        
        public ActionResult CadastrarAtendenteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                return View("CadastrarAtendenteUI");
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarAtendenteAR(string txtNomeAtendente, string txtEmailAtendente, string txtSenhaAtendente, string selSituacaoAtendente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                Atendente atendente = atendenteDAL.SelecionarAtendenteEmail(txtEmailAtendente);
                Usuario usuario = usuarioDAL.SelecionarUsuarioEmail(txtEmailAtendente);

                if ((usuario.EmailUsuario != null) || (atendente.EmailAtendente != null))
                {
                    TempData[Constantes.MensagemAlerta] = "Já existe atendente vinculado a este e-mail!";
                    return View("CadastrarAtendenteUI");
                }
                else
                {
                    usuario = new Usuario(txtEmailAtendente, txtSenhaAtendente, atendente.TipoUsuarioAtendente, Convert.ToChar(selSituacaoAtendente));
                    atendente = new Atendente(txtNomeAtendente, txtEmailAtendente, Convert.ToChar(selSituacaoAtendente));

                    usuarioDAL.CadastrarUsuario(usuario);
                    atendenteDAL.CadastrarAtendente(atendente);

                    TempData[Constantes.MensagemAlerta] = "Atendente cadastrado com sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }                           
        }

        [HttpGet]
        public ActionResult AlterarAtendenteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
                return View(atendenteControllerModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }
                      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarAtendenteAR(string txtCodigoAtendente, string txtNomeAtendente, string selSituacaoAtendente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                Atendente atendente = atendenteDAL.SelecionarAtendenteId(Convert.ToInt32(txtCodigoAtendente));

                if (atendente.CodigoAtendente == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Atendente para o código digitado.";
                    AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
                    return View("AlterarAtendenteUI", atendenteControllerModel);
                }
                else
                {
                    atendente = new Atendente(Convert.ToInt32(txtCodigoAtendente), txtNomeAtendente, Convert.ToChar(selSituacaoAtendente));
                    atendenteDAL.AlterarAtendente(atendente);
                    TempData[Constantes.MensagemAlerta] = "Atendente Alterado com Sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }                                   
        }        

        [HttpGet]
        public JsonResult SelecionarAtendenteJR(int codigoAtendente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                Atendente atendente = atendenteDAL.SelecionarAtendenteId(codigoAtendente);
                return Json(atendente, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Esta informação não pode ser solicitada. Por favor, contate o administrador do sistema.", JsonRequestBehavior.AllowGet);
            }            
        }

        [HttpGet]
        public ActionResult ConsultarAtendenteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
                return View(atendenteControllerModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public ActionResult ExcluirAtendenteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
                return View(atendenteControllerModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirAtendenteAR(string txtCodigoAtendente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                AtendenteDAL atendenteDAL = new AtendenteDAL();
                Atendente atendente = atendenteDAL.SelecionarAtendenteId(Convert.ToInt32(txtCodigoAtendente));

                if (atendente.CodigoAtendente == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Atendente para o código digitado.";
                    AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
                    return View("ExcluirAtendenteUI", atendenteControllerModel);
                }
                else
                {
                    atendente.CodigoAtendente = Convert.ToInt32(txtCodigoAtendente);
                    atendenteDAL.ExcluirAtendente(atendente);
                    TempData[Constantes.MensagemAlerta] = "Atendente Excluído com Sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }                 
        }        
    }
}