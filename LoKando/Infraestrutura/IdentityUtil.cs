using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Infraestrutura
{
    public static class IdentityUtil
    {
        public static UserManager<IdentityUser> UserManager
        {
            get => HttpContext.Current.GetOwinContext().GetUserManager<UserManager<IdentityUser>>();
        }

        public static SignInManager<IdentityUser, string> SignInManager
        {
            get => HttpContext.Current.GetOwinContext().GetUserManager<SignInManager<IdentityUser, string>>();
        }

        public static IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.Current.Request.GetOwinContext().Authentication;
        }

    }
}