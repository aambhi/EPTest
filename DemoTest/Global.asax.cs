using System.Web.Mvc;
using System.Web.Routing;

namespace DemoTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Register the dependencies, when the application starts.
            UnityContainerRegistration.InitialiseContainer();
        }
    }
}
