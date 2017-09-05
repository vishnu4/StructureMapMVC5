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
        public HomeController(Services.IBasicService basicService)
        {
            _basicService = basicService;
        }
        public ActionResult Index()
        {
            ViewBag.Result = _basicService.ExecuteDBMethod();
            return View();
        }
        
    }
}