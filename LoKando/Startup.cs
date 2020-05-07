using LoKando.DAL.Conn;
using LoKando.Models.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;
using System.Data.Entity;

[assembly: OwinStartup(typeof(LoKando.Startup))]
namespace LoKando
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.CreatePerOwinContext<DbContext>(() => new EntityContext());

            app.CreatePerOwinContext<UserStore<CustomIdentityUser>>((option, contextoOwin) =>
            {
                var dbContext = contextoOwin.Get<DbContext>();
                return new UserStore<CustomIdentityUser>(dbContext);
            });

            app.CreatePerOwinContext<RoleStore<IdentityRole>>((option, contextoOwin) =>
            {
                var dbContext = contextoOwin.Get<DbContext>();
                return new RoleStore<IdentityRole>(dbContext);
            });

            app.CreatePerOwinContext<RoleManager<IdentityRole>>((option, contextOwin) =>
            {
                var roleStore = contextOwin.Get<RoleStore<IdentityRole>>();
                return new RoleManager<IdentityRole>(roleStore);
            });

            app.CreatePerOwinContext<UserManager<CustomIdentityUser>>((option, contextoOwin) =>
            {
                var userStore = contextoOwin.Get<UserStore<CustomIdentityUser>>();
                var userManager = new UserManager<CustomIdentityUser>(userStore);

                return userManager;
            });

            app.CreatePerOwinContext<SignInManager<CustomIdentityUser, string>>((option, contextoOwin) =>
            {
                var userManager = contextoOwin.Get<UserManager<CustomIdentityUser>>();
                return new SignInManager<CustomIdentityUser, string>(userManager, contextoOwin.Authentication);
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            using (var dbContext = new EntityContext())
            {
                CriarRoles(dbContext);
                CriarAdmin(dbContext);
            }
        }

        private void CriarRoles(DbContext dbContext)
        {
            using (var roleStore = new RoleStore<IdentityRole>(dbContext))
            using (var roleManager = new RoleManager<IdentityRole>(roleStore))
            {
                if (!roleManager.RoleExists(Constantes.ADMINISTRADOR))
                    roleManager.Create(new IdentityRole(Constantes.ADMINISTRADOR));

                if (!roleManager.RoleExists(Constantes.ATENDENTE))
                    roleManager.Create(new IdentityRole(Constantes.ATENDENTE));
            }
        }

        private void CriarAdmin(DbContext dbContext)
        {
            using (var userStore = new UserStore<CustomIdentityUser>(dbContext))
            using (var userManager = new UserManager<CustomIdentityUser>(userStore))
            {
                var emailAdmin = ConfigurationManager.AppSettings["admin:email"];               
                
                if (userManager.FindByEmail(emailAdmin) == null)
                {
                    CustomIdentityUser identityUser = new CustomIdentityUser();
                    identityUser.Email = emailAdmin;
                    identityUser.UserName = ConfigurationManager.AppSettings["admin:username"];
                    identityUser.EmailConfirmed = true;
                    identityUser.FullName = identityUser.UserName;

                    userManager.Create(identityUser, ConfigurationManager.AppSettings["admin:password"]);
                    userManager.AddToRole(identityUser.Id, Constantes.ADMINISTRADOR);
                }
            }
        }
        
    }
}
