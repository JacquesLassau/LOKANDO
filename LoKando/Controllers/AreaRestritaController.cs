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
        // GET: AreaRestrita
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult LoginAR()
        {
            return RedirectToAction("Index", "Inicio");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult LogoutAR()
        {
            return RedirectToAction("Login", "AreaRestrita");
        }
    }
}