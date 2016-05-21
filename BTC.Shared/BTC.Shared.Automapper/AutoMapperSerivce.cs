using System.Linq;
using Ninject;

namespace BTC.Shared.Automapper
{
    public class AutoMapperSerivce
    {
        private readonly IKernel _kernel;

        public AutoMapperSerivce(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void RegisterMapperConfigs<T>()
        {
            var potencialConfig = typeof(T).Assembly.GetTypes()
                .Where(n => !n.IsAbstract && n.IsClass && typeof(IMapConfig).IsAssignableFrom(n));
            foreach (var type in potencialConfig)
            {
                var config = (IMapConfig)_kernel.Get(type);
                config.ConfigMapToDestination();
                config.ConfigMapToSourse();
            }
        }
    }
}