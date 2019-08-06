using AppPracticeSatrack.Interfaces;
using AppPracticeSatrack.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Configuration
{
    public class AppPracticeStrackCrossModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<IVehicleRepository>().To<VehicleRepository>();
        }

    }
}
