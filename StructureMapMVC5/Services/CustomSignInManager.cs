using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StructureMapMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Services
{
    public class CustomSignInManager : SignInManager<ApplicationUser, string>
    {
        public CustomSignInManager(CustomUserManager userManager, IAuthenticationManager authenticationManager, Services.IBasicService basicService,Models.IDBMethod myMethod)
            : base(userManager, authenticationManager)
        {
            
        }
    }
}