using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Folferine.Website.Container;
using Folferine.Website.Controllers;
using Folferine.Website.Infrastructure;
using GameRepository = Folferine.Website.Infrastructure.GameRepository;

namespace Folferine.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private WindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfiguration.Configure();

            container = new WindsorContainer();

            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IController))
                .LifestyleTransient());

            var folferineConnectionString = ConfigurationManager.ConnectionStrings["FolferineContext"].ConnectionString;
            container.Register(Component.For<FolferineContext>().UsingFactoryMethod(x =>
                new FolferineContext(folferineConnectionString)).LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<GameRepository>().InSameNamespaceAs<GameRepository>()
                .WithServiceAllInterfaces().LifestylePerWebRequest());
     
            ControllerBuilder.Current.SetControllerFactory(new CastleWindsorControllerFactory(container));
        }

        protected void Application_End()
        {
            if (container != null)
            {
                container.Dispose();
            }
        }
    }
}
