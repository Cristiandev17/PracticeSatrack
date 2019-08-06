using AppPracticeSatrack.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Interfaces
{
    public interface IEmployeeRepository
    {
        ObservableCollection<EmployeeModel> GetEmployees();

        string AddEmployee(EmployeeModel employee);

        string DeleteEmployee(string Id);
    }
}
