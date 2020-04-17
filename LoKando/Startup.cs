using LoKando.DAL.Conn;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
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

            app.CreatePerOwinContext<UserStore<IdentityUser>>((option, contextoOwin) =>
            {
                var dbContext = contextoOwin.Get<DbContext>();
                return new UserStore<IdentityUser>(dbContext);
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

            app.CreatePerOwinContext<UserManager<IdentityUser>>((option, contextoOwin) =>
            {
                var userStore = contextoOwin.Get<UserStore<IdentityUser>>();
                return new UserManager<IdentityUser>(userStore);
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
            }
        }

        private void CriarAdmin(DbContext dbContext)
        {
            using (var userStore = new UserStore<IdentityUser>(dbContext))
            using (var userManager = new UserManager<IdentityUser>(userStore))
            {
                var emailAdmin = ConfigurationManager.AppSettings["admin:email"];
                if (userManager.FindByEmail(emailAdmin) == null)
                {
                    IdentityUser identityUser = new IdentityUser();
                    identityUser.Email = emailAdmin;
                    identityUser.UserName = ConfigurationManager.AppSettings["admin:username"];
                    identityUser.EmailConfirmed = true;

                    userManager.Create(identityUser, ConfigurationManager.AppSettings["admin:password"]);
                    userManager.AddToRole(identityUser.Id, Constantes.ADMINISTRADOR);
                }
            }
        }
    }
}
