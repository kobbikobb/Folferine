using System;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace Folferine.Website.Container
{
    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IWindsorContainer container;

        public CastleWindsorControllerFactory(IWindsorContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path {0} cannot be found.",
                    requestContext.HttpContext.Request.Path));
            }

            return (IController)container.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            container.Release(controller);
            base.ReleaseController(controller);
        }
    }
}