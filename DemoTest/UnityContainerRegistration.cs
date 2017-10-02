using DemoTest.Core.RepositoryInterface;
using DemoTest.Infrastructure.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;

namespace DemoTest
{
    public class UnityContainerRegistration
    {
        public static IUnityContainer InitialiseContainer()
        {
            // Initialize the container
            var container = new UnityContainer();

            // Register the dependency
            container.RegisterType<IProfile, ProfileRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}