using AppPracticeSatrack.Models;
using AppPracticeSatrack.Pages;
using AppPracticeSatrack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ninject;
using AppPracticeSatrack.Repositories;

namespace AppPracticeSatrack.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        public EmployeesViewModel()
        {
            GetEmployees();
        }

        public bool HasEmployees => Employees.Count >= 1;

        private async void GetEmployees()
        {
            var employeesCurrent = EmployeeRepository.GetEmployees();
            if (employeesCurrent != null && employeesCurrent.Count >= 1)
                Employees = employeesCurrent;
            else
            {
                Employees = new ObservableCollection<EmployeeModel>()
                {
                    new EmployeeModel
                    {
                        Name = "Cristian",
                        LastName = "Aristizabal",
                        Position = "Developer",
                        Salary = 200,
                    },
                    new EmployeeModel
                    {
                        Name = "Camilo",
                        LastName = "Tobon",
                        Position = "Developer",
                        Salary = 400,
                    },
                    new EmployeeModel
                    {
                        Name = "David",
                        LastName = "Guzman",
                        Position = "Tester",
                        Salary = 100,
                    },
                };
            }
        }

        private ObservableCollection<EmployeeModel> employees;
        public ObservableCollection<EmployeeModel> Employees
        {
            get => employees;
            set => Set(ref employees, value);
        }

        public ICommand GoAddEmployeeCommand { get { return new RelayCommand(GoAddEmployee); } }

        private async void GoAddEmployee()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddEmployeesPage());
        }

        public ICommand RefreshCommand { get { return new RelayCommand(Refresh); } }

        private async void Refresh()
        {
            GetEmployees();
        }

        public ICommand DeleteEmployeeCommand { get { return new RelayCommand<EmployeeModel>(DeleteEmployee); } }

        private void DeleteEmployee(EmployeeModel obj)
        {
            
            var result = EmployeeRepository.DeleteEmployee(obj.Id);
            if (result == "ok")
            {
                Employees.Remove(obj);
            }
        }
    }
}
