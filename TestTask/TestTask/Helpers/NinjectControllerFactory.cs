using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Configuration;
using TestTask.Models.Repository;

namespace TestTask.Helpers
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(
            RequestContext requestContext,
            Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
        private void AddBindings() 
        {

            //accessConnection
            //myConnection
            string connStr = WebConfigurationManager.
                ConnectionStrings["productContext"].
                ConnectionString; _kernel.
                    Bind<IRepository>().
                    ToConstant(new Repository(connStr)); 
        }
    }
}
