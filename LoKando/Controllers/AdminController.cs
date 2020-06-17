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
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }
    }
}