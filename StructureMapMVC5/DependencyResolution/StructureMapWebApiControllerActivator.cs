using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

public class StructureMapWebApiControllerActivator : IHttpControllerActivator
{
    private readonly IContainer _container;

    public StructureMapWebApiControllerActivator(IContainer container)
    {
        _container = container;
    }

    public IHttpController Create(
        HttpRequestMessage request,
        HttpControllerDescriptor controllerDescriptor,
        Type controllerType)
    {
        var nested = _container.GetNestedContainer();
        var instance = nested.GetInstance(controllerType) as IHttpController;
        request.RegisterForDispose(nested);
        return instance;
    }
}
