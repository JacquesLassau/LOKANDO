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
    public class VeiculoController : Controller
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
        public ActionResult CadastrarVeiculoUI()
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = ConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);            
        }
    }
}