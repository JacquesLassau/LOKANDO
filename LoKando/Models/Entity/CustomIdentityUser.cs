using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoKando.Models.Entity
{
    public class CustomIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}