using System.Web.Mvc;
using Microsoft.Practices.Unity;
using SignalRTest.Data.UnitOfWork;
using Unity.Mvc5;

namespace SignalRTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, DevTestUnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}