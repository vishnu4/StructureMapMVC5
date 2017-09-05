using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using StructureMapMVC5.App_Start;
using StructureMapMVC5.DependencyResolution;

[assembly: OwinStartup(typeof(StructureMapMVC5.Startup))]
namespace StructureMapMVC5
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = StructuremapMvc.StructureMapDependencyScope.Container;
            var dicontainer = new StructureMapDependencyInjectionContainer(container);
            var controllerFactory = new InjectableControllerFactory(dicontainer);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //configure OWIN authorization
            //ConfigureAuth(app);
            //config OAuth configuration, which allows token based web api access
            //http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/
            HttpConfiguration config = new HttpConfiguration();
            //ConfigureOAuth(app);
            WebApiConfig.Register(config);
            //http://cdroulers.com/blog/2015/03/03/structuremap-3-and-asp-net-web-api-2/
            config.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerActivator), new StructureMapWebApiControllerActivator(container));

            app.UseCors(CorsOptions.AllowAll);

        }
    }

}