using LoKando.Models.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace LoKando.DAL.Conn
{
    public class EntityContext : IdentityDbContext<CustomIdentityUser>
    {
        public EntityContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {

        }
    }
}