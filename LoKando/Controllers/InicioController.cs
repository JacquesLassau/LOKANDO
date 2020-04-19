using LoKando.Filters;
using System.Web.Mvc;

namespace LoKando.Controllers
{
    [CustomAuthorize]
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}