namespace CodeDemoSolution.Web.App_Start
{
    using Microsoft.Practices.Unity;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class IocDependencyResolver : IDependencyResolver, IDisposable
    {
        private IUnityContainer Container { get; set; }

        public IocDependencyResolver(IUnityContainer container)
        {
            this.Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.Container.Resolve(serviceType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.Container.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}