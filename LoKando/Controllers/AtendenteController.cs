using System;
using LoKando.Models;
using LoKando.DAL;
using System.Collections.Generic;
using System.Web.Mvc;
using LoKando.Models.ControllerModel;
using LoKando.Filters;
using LoKando.Infraestrutura;
using Microsoft.AspNet.Identity;
using LoKando.Models.Entity;
using System.Linq;

namespace LoKando.Controllers
{
    [CustomAuthorize]
    public class AtendenteController : Controller
    {
        public AtendenteControllerModel ConvertToModel(List<Atendente> listaAtendente)
        {
            AtendenteControllerModel atendenteControllerModel = new AtendenteControllerModel();
            if (listaAtendente != null)
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
            return View("CadastrarAtendenteUI");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarAtendenteAR(string txtNomeAtendente, string txtEmailAtendente, string txtSenhaAtendente, string selSituacaoAtendente)
        {
            try
            {
                var userNameTratado = txtNomeAtendente.Replace(" ", "").ToLower();

                if (IdentityUtil.UserManager.FindByEmail(txtEmailAtendente) != null)
                {
                    TempData[Constantes.MensagemAlerta] = "Já existe um atendente vinculado a este e-mail!";
                    return View("CadastrarAtendenteUI");
                }
                if (IdentityUtil.UserManager.FindByName(userNameTratado) != null)
                {
                    TempData[Constantes.MensagemAlerta] = "Já existe um atendente com esse nome de usuário!";
                    return View("CadastrarAtendenteUI");
                }

                CustomIdentityUser customIdentityUser = new CustomIdentityUser();
                customIdentityUser.FullName = txtNomeAtendente;
                customIdentityUser.Email = txtEmailAtendente;
                customIdentityUser.EmailConfirmed = true;
                customIdentityUser.UserName = userNameTratado;

                var result = IdentityUtil.UserManager.Create(customIdentityUser, txtSenhaAtendente);

                IdentityUtil.UserManager.AddToRole(customIdentityUser.Id, Constantes.ATENDENTE);

                if (!result.Succeeded)
                {
                    TempData[Constantes.MensagemAlerta] = result.Errors.FirstOrDefault();
                    return View("CadastrarAtendenteUI");
                }

                TempData[Constantes.MensagemAlerta] = "Atendente cadastrado com sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
            catch (Exception ex)
            {
                TempData[Constantes.MensagemAlerta] = ex.Message;
                return View("CadastrarAtendenteUI");
            }
        }

        [HttpGet]
        public ActionResult AlterarAtendenteUI()
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
            return View(atendenteControllerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarAtendenteAR(string txtCodigoAtendente, string txtNomeAtendente, string selSituacaoAtendente)
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            Atendente atendente = atendenteDAL.SelecionarAtendenteId(Convert.ToInt32(txtCodigoAtendente));

            if (atendente.CodigoAtendente == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Atendente para o código digitado... Tente novamente!";
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

        [HttpGet]
        public JsonResult SelecionarAtendenteJR(int codigoAtendente)
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            Atendente atendente = atendenteDAL.SelecionarAtendenteId(codigoAtendente);
            return Json(atendente, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConsultarAtendenteUI()
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
            return View(atendenteControllerModel);
        }

        [HttpGet]
        public ActionResult ExcluirAtendenteUI()
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            AtendenteControllerModel atendenteControllerModel = ConvertToModel(atendenteDAL.ListarAtendente());
            return View(atendenteControllerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirAtendenteAR(string txtCodigoAtendente)
        {
            AtendenteDAL atendenteDAL = new AtendenteDAL();
            Atendente atendente = atendenteDAL.SelecionarAtendenteId(Convert.ToInt32(txtCodigoAtendente));

            if (atendente.CodigoAtendente == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Atendente para o código digitado... Tente novamente!";
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


    }
}