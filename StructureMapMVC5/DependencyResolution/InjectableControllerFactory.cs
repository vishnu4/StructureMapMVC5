using System;
using System.Web.Routing;
using System.Web.Mvc;

namespace StructureMapMVC5.DependencyResolution
{
    internal class InjectableControllerFactory
        : DefaultControllerFactory
    {
        private readonly IDependencyInjectionContainer container;

        public InjectableControllerFactory(IDependencyInjectionContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext.HttpContext.Request.Url.ToString().EndsWith("favicon.ico",System.StringComparison.OrdinalIgnoreCase))
                return null;
            if (requestContext.HttpContext.Request.Url.ToString().EndsWith(".map", System.StringComparison.OrdinalIgnoreCase))
                return null;
            if (requestContext.HttpContext.Request.Url.ToString().EndsWith(".map;", System.StringComparison.OrdinalIgnoreCase))
                return null;
            //if (requestContext.HttpContext.Request.Url.ToString().EndsWith(".css;", System.StringComparison.OrdinalIgnoreCase))
            //    return null;
            //if (requestContext.HttpContext.Request.Url.ToString().EndsWith(".js;", System.StringComparison.OrdinalIgnoreCase))
            //    return null;
            //try   //this error handling seems like it'd make sense, but it screws up our custom errors, so leave it blank for now
            //{
            IController ret = controllerType == null ?
                    base.GetControllerInstance(requestContext, controllerType) :
                    container.GetInstance(controllerType) as IController;
                return ret;
            //}
            //catch (Exception ex)
//            {
//#if DEBUG
//                Console.WriteLine(ex.Message);
//#endif 
//                return null;
//            }
        }

        public override void ReleaseController(IController controller)
        {
            this.container.Release(controller);
        }
    }
}
