using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Configuration
{
    public static class ServiceLocator
    {
        public static bool IsKernelKK { get; set; }

        private static IKernel _kernel;

        public static void ConfigureKernel(IEnumerable<NinjectModule> modules)
        {
            _kernel = new StandardKernel(modules.ToArray());
            IsKernelKK = true;
        }

        static void EnsureKernelIsReady()
        {
            if (_kernel == null)
            {
                IsKernelKK = false;
                throw new InvalidOperationException(
                    "Cannot inject with a null kernel. Call ConfigureKernel first");
            }
        }

        public static void Inject(object target)
        {
            EnsureKernelIsReady();
            _kernel.Inject(target);
        }
    }
}
