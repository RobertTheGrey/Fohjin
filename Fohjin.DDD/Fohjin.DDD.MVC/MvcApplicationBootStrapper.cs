using System;
using System.Web.Mvc;
using System.Web.Routing;
using Fohjin.DDD.Configuration;
using Fohjin.DDD.Services;
using StructureMap;

namespace Fohjin.DDD.MVC
{
    public static class MvcApplicationBootStrapper
    {
        public static void BootStrap()
        {
            DomainDatabaseBootStrapper.BootStrap();
            ReportingDatabaseBootStrapper.BootStrap();

            ObjectFactory.Initialize(
                container =>
                    {
                        container.Scan(scanner =>
                                           {
                                               scanner.TheCallingAssembly();
                                               scanner.WithDefaultConventions();
                                               scanner.AddAllTypesOf<IController>();
                                           });
                        container.AddRegistry<DomainRegistry>();
                        container.AddRegistry<ReportingRegistry>();
                        container.AddRegistry<ServicesRegister>();
            });
            ObjectFactory.AssertConfigurationIsValid();

            RegisterCommandHandlersInMessageRouter.BootStrap();
            RegisterEventHandlersInMessageRouter.BootStrap();

        }

        public static DefaultControllerFactory GetControllerFactory()
        {
            return new StructureMapControllerFactory();
        }

        #region Nested type: StructureMapControllerFactory

        private class StructureMapControllerFactory : DefaultControllerFactory
        {
            protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
            {
                return ObjectFactory.GetInstance(controllerType) as IController;
            }
        }

        #endregion
    }
}