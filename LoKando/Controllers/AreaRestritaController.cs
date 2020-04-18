using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoKando.Controllers
{
    public class AreaRestritaController : Controller
    {
        // GET: AreaRestrita
        public ActionResult LoginUI()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUsuarioAR(string txtEmailUsuario, string txtSenhaUsuario)
        {
            return RedirectToAction("Index", "Inicio");
        }
    }
}