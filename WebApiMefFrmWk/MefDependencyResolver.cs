using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Http.Dependencies;

namespace WebApiMefFrmWk
{
    public class MefDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver,  System.Web.Mvc.IDependencyResolver
    {

        private readonly CompositionContainer _containter;

        public MefDependencyResolver(CompositionContainer container)
        {
            _containter = container;
        }
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (null==  serviceType)
            {
                throw new NullReferenceException("serviceType");
            }
            var name = AttributedModelServices.GetContractName(serviceType);
            return null == name ? null :_containter.GetExportedValueOrDefault<object>(name);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (null==serviceType)
            {
                throw new NullReferenceException("serviceType");
            }
            var name =AttributedModelServices.GetContractName(serviceType);
            return null == name ? null : _containter.GetExportedValues<object>(name);
        }

        public void Dispose()
        {
            if (_containter!=null)
            {
                _containter.Dispose();
            }
         }
    }
}
