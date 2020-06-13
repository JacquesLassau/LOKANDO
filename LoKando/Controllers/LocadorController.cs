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
    public class LocadorController : Controller
    {
        public LocadorControllerModel ConvertToModel(List<Locador> listaLocador)
        {
            LocadorControllerModel locadorControllerModel = new LocadorControllerModel();
            if (listaLocador != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach (var locador in listaLocador)
                {
                    locadorControllerModel.Locador.Add(locador);
                }
            }

            return locadorControllerModel;
        }


        [HttpGet]
        public ActionResult CadastrarLocadorUI()
        {
            return View("CadastrarLocadorUI");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarLocadorAR(string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtSenhaLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtDocumentoLocador, string txtEnderecoLocador, string txtBairroLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
        {

            LocadorDAL locadorDAL = new LocadorDAL();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Locador locador = new Locador();
            Usuario usuario = new Usuario();

            Locador locadorEmail = locadorDAL.SelecionarLocadorEmail(txtEmailLocador);
            Locador docLocador = locadorDAL.SelecionarLocadorDoc(txtDocumentoLocador);
            Usuario usuarioEmail = usuarioDAL.SelecionarUsuarioEmail(txtEmailLocador);

            if ((usuarioEmail.EmailUsuario != null) || (locadorEmail.EmailLocador != null))
            {
                TempData[Constantes.MensagemAlerta] = "Já existe um locador vinculado a este e-mail!";
                return View("CadastrarLocadorUI");
            }
            else if (docLocador.CpfCnpjLocador != null)
            {
                TempData[Constantes.MensagemAlerta] = "Já existe um locador vinculado a este documento!";
                return View("CadastrarLocadorUI");
            }
            else
            {
                usuario = new Usuario(txtEmailLocador, txtSenhaLocador, locador.TipoUsuarioLocador, Convert.ToChar(selSituacaoLocador));
                locador = new Locador(txtEmailLocador, txtRzScLocador, txtNmFsLocador, txtDocumentoLocador, txtTelefoneLocador, txtEnderecoLocador, txtBairroLocador, txtCidadeLocador, selEstadoLocador, txtCepLocador, Convert.ToChar(selSituacaoLocador));

                usuarioDAL.CadastrarUsuario(usuario);
                locadorDAL.CadastrarLocador(locador);

                TempData[Constantes.MensagemAlerta] = "Locador cadastrado com sucesso!";
                return RedirectToAction("Index", "Inicio");
            }

        }

        [HttpGet]
        public ActionResult AlterarLocadorUI()
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarLocadorAR(string txtCodigoLocador, string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtEnderecoLocador, string txtBairroLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            Locador locador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));              

            if (locador.CodigoLocador == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Locador para o código digitado... Tente novamente!";
                return View("AlterarLocadorUI");
            }            
            else
            {                
                locador = new Locador(Convert.ToInt32(txtCodigoLocador), txtRzScLocador, txtNmFsLocador, txtTelefoneLocador, txtEnderecoLocador, txtBairroLocador, txtCidadeLocador, selEstadoLocador, txtCepLocador, Convert.ToChar(selSituacaoLocador));
                locadorDAL.AlterarLocador(locador);
                TempData[Constantes.MensagemAlerta] = "Locador alterado com sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
        }

        [HttpGet]
        public JsonResult SelecionarLocadorJR(int codigoLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            Locador locador = locadorDAL.SelecionarLocadorId(codigoLocador);
            return Json(locador, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConsultarLocadorUI()
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);
        }

        [HttpGet]
        public ActionResult ExcluirLocadorUI()
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirLocadorAR(string txtCodigoLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            Locador locador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));

            if (locador.CodigoLocador == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Locador para o código digitado... Tente novamente!";
                LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());                
                return View("ExcluirLocadorUI", locadorViewModel);
            }
            else
            {
                locador = new Locador(Convert.ToInt32(txtCodigoLocador));
                locadorDAL.ExcluirLocador(locador);
                TempData[Constantes.MensagemAlerta] = "Locador excluído com sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
        }

    }
}