using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using WebApiImplementation;
using WebApiInterface;
using WebApiMefFrmWk;
namespace WebApiMef.App_Start
{
    public static class MefConfig
    {
        public static  void SetMefContainer(HttpConfiguration config)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(IMEFInterface).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MEFImplementation).Assembly));
            CompositionContainer container = new CompositionContainer(catalog);
            MefDependencyResolver resolver = new MefDependencyResolver(container);
            config.DependencyResolver = resolver;
            DependencyResolver.SetResolver(resolver);
        }
    }
}