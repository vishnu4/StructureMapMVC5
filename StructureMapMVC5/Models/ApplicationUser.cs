﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Models
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }
    }
}