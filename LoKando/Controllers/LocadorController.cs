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
        public ActionResult CadastrarLocadorAR(string txtRzScLocador, string txtNmFsLocador, string txtEmailLocador, string txtSenhaLocador, string txtTelefoneLocador, string selSituacaoLocador, string txtCpfLocador, string txtCnpjLocador, string txtEnderecoLocador, string txtCidadeLocador, string selEstadoLocador, string txtCepLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Locador locador = new Locador();
            Usuario usuario = new Usuario();



            return RedirectToAction("Index", "Inicio");
        }
    }
}