using CodeDemoSolution.DataAccess.Context;
using CodeDemoSolution.DataAccess.Interfaces.Context;
using CodeDemoSolution.DataAccess.Interfaces.UnitOfWork;
using CodeDemoSolution.DataAccess.UnitOfWork;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeDemoSolution.Web.App_Start
{
    public class IocContainer
    {
        public static IUnityContainer ConfigureIocContainer()
        {
            // Get our IoC Container
            IUnityContainer container = new UnityContainer();

            // Register any custom components we know we have.
            registerComponents(container);

            return container;
        }

        public static IDependencyResolver GetDependencyResolver(IUnityContainer container)
        {
            // Return our custom unity container dependency resolver for web api to work with.
            return new IocDependencyResolver(container);
        }

        private static void registerComponents(IUnityContainer container)
        {
            container.RegisterType<ITodoDbContext, TodoDbContext>("DbContext");
            container.RegisterType<ITodoUnitOfWork, TodoUnitOfWork>(new InjectionConstructor(new ResolvedParameter<ITodoDbContext>("DbContext")));
        }
    }
}