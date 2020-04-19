using LoKando.Filters;
using LoKando.Infraestrutura;
using LoKando.Models.ControllerModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;

namespace LoKando.Controllers
{
    public class AreaRestritaController : Controller
    {
        // GET: AreaRestrita
        [AlreadySignIn]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AlreadySignIn]
        public ActionResult Login(LoginAutenticadorControllerModel pModel)
        {
            var user = IdentityUtil.UserManager.FindByEmail(pModel.Email);
            if (user == null)
            {
                TempData["Error"] = "Não foi possível realizar a autenticação!";
                pModel.Senha = null;
                return View(pModel);                
            }
            else
            {
                var result = IdentityUtil.SignInManager.PasswordSignIn(user.UserName, pModel.Senha, pModel.ManterConectador, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToAction("Index", "Inicio");
                    default:
                        TempData["Error"] = "Não foi possível realizar a autenticação!";
                        pModel.Senha = null;
                        return View(pModel);
                }
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize]
        public ActionResult Logout()
        {
            IdentityUtil.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}