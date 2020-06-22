using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace RssReader.ViewModel
{
    public class DependencyInjector
    {
        private static readonly UnityContainer unityContainer = new UnityContainer();

        public static void Register<I, T>() where T : I
        {
            unityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }

        public static T Retrieve<T>()
        {
            return unityContainer.Resolve<T>();
        }

        public static void Inject<I>(I instance)
        {
            unityContainer.RegisterInstance<I>(instance, new ContainerControlledLifetimeManager());
        }
    }
}
