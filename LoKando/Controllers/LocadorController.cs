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
        public ActionResult CadastrarLocadorAR(string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtSenhaLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtDocumentoLocador, string txtEnderecoLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
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
                usuario = new Usuario(txtEmailLocador, txtSenhaLocador, Convert.ToChar(selSituacaoLocador));
                locador = new Locador(txtEmailLocador, txtRzScLocador, txtNmFsLocador, txtDocumentoLocador, txtTelefoneLocador, txtEnderecoLocador, txtCidadeLocador, selEstadoLocador, txtCepLocador, Convert.ToChar(selSituacaoLocador));

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

        public ActionResult AlterarLocadorAR()
        {
            return RedirectToAction("Index", "Inicio");
        }

        [HttpGet]
        public JsonResult SelecionarLocadorJR(int codigoLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            Locador locador = locadorDAL.SelecionarLocadorId(codigoLocador);
            return Json(locador, JsonRequestBehavior.AllowGet);
        }

    }
}