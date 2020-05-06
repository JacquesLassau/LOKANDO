using LoKando.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;

namespace LoKando.Infraestrutura
{
    public static class IdentityUtil
    {
        public static UserManager<CustomIdentityUser> UserManager
        {
            get => HttpContext.Current.GetOwinContext().GetUserManager<UserManager<CustomIdentityUser>>();
        }

        public static SignInManager<CustomIdentityUser, string> SignInManager
        {
            get => HttpContext.Current.GetOwinContext().GetUserManager<SignInManager<CustomIdentityUser, string>>();
        }

        public static IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.Current.Request.GetOwinContext().Authentication;
        }

    }
}