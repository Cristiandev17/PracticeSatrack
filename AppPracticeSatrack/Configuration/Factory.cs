using AppPracticeSatrack.ViewModels;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Configuration
{
    public static class Factory
    {
        private static IKernel kernel = null;
        public static T Resolve<T>()
        {
            if (kernel == null)
            {
                CreateKernel();
            }
            return kernel.Get<T>();
        }

        public static void CreateKernel(NinjectModule module = null)
        {
            if (module != null)
                kernel = new StandardKernel(new AppPracticeStrackCrossModule(), module);
            else
                kernel = new StandardKernel(new AppPracticeStrackCrossModule());
        }

        internal static void Inject(object target)
        {
            if (kernel != null)
                kernel.Inject(target);
        }
    }
}
