using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace BTC.Shared.IoC
{
    public static class IoC
    {
        private static StandardKernel _instance;

        public static IKernel Instance => _instance ?? (_instance = new StandardKernel());
    }
}
