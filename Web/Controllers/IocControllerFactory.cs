using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using IoC;

namespace Web.Controllers
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        private readonly Container _container;

        public IocControllerFactory(Container container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType.GetConstructors().Any(c => c.GetParameters().Length == 0))
                return Activator.CreateInstance(controllerType) as Controller;
            foreach (var constructor in controllerType.GetConstructors())
            {
                try
                {
                    var parameters = (from pi in constructor.GetParameters()
                        let resolver = typeof(Container).GetMethod("Resolve")
                        where resolver != null
                        select resolver.MakeGenericMethod(pi.ParameterType)
                        into tResolver
                        select tResolver.Invoke(ContainerConfig.Container, null));
                    return constructor.Invoke(parameters.ToArray()) as Controller;
                }
                catch (UnknownTypeException)
                {
                    // We don't know all the parameter type for this constructor. Try the next constructor.
                }
            }

            // If we fail to create the controller, try the base factory.
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}