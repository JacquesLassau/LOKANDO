using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace LoKando.DAL.Conn
{
    public class EntityContext : IdentityDbContext
    {
        public EntityContext() : base(ConfigurationManager.AppSettings["ConnectionString"])
        {

        }
    }
}