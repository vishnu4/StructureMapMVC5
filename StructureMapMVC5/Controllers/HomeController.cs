using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StructureMapMVC5.Controllers
{
    public class HomeController : Controller
    {
        Services.IBasicService _basicService;
        Services.CustomSignInManager _signMan;
        public HomeController(Services.IBasicService basicService, Services.CustomSignInManager signMan)
        {
            _basicService = basicService;
            _signMan = signMan;
        }
        public ActionResult Index()
        {
            ViewBag.Result = _basicService.ExecuteDBMethod();
            return View();
        }
        
    }
}