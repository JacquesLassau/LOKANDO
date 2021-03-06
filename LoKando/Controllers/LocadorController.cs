﻿using System;
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

        [ChildActionOnly]
        public PartialViewResult _ModalConsultaLocador()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult CadastrarLocadorUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                return View("CadastrarLocadorUI");
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarLocadorAR(string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtSenhaLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtDocumentoLocador, string txtEnderecoLocador, string txtBairroLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
        {
            if (ValidarAdmin.UsuarioValido())
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
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            

        }

        [HttpGet]
        public ActionResult AlterarLocadorUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
                return View(locadorViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarLocadorAR(string txtCodigoLocador, string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtEnderecoLocador, string txtBairroLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                Locador locador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));

                if (locador.CodigoLocador == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Locador para o código digitado.";
                    LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
                    return View("AlterarLocadorUI", locadorViewModel);
                }
                else
                {
                    locador = new Locador(Convert.ToInt32(txtCodigoLocador), txtRzScLocador, txtNmFsLocador, txtTelefoneLocador, txtEnderecoLocador, txtBairroLocador, txtCidadeLocador, selEstadoLocador, txtCepLocador, Convert.ToChar(selSituacaoLocador));
                    locadorDAL.AlterarLocador(locador);
                    TempData[Constantes.MensagemAlerta] = "Locador alterado com sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public JsonResult SelecionarLocadorJR(int codigoLocador)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                Locador locador = locadorDAL.SelecionarLocadorId(codigoLocador);
                return Json(locador, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Esta informação não pode ser solicitada. Por favor, contate o administrador do sistema.", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult ConsultarLocadorUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
                return View(locadorViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public ActionResult ExcluirLocadorUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
                return View(locadorViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirLocadorAR(string txtCodigoLocador)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                Locador locador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));

                if (locador.CodigoLocador == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Locador para o código digitado.";
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
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }
    }
}