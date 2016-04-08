using CodeDemoSolution.Web.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeDemoSolution.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = IocContainer.ConfigureIocContainer();
            DependencyResolver.SetResolver(IocContainer.GetDependencyResolver(container));
        }
    }
}
