using Microsoft.AspNet.Identity;
using StructureMapMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Services
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager()
            : base(new CustomUserStore<ApplicationUser>())
        {
        }
    }
}