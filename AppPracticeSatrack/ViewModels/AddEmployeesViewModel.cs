using AppPracticeSatrack.Configuration;
using AppPracticeSatrack.Interfaces;
using AppPracticeSatrack.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppPracticeSatrack.ViewModels
{
    public class AddEmployeesViewModel : BaseViewModel
    {

        IEmployeeRepository EmployeeRepository;

        public AddEmployeesViewModel()
        {
            ServiceLocator.Inject(this);
        }

        [Inject]
        public void ReciveInterface(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }
        private string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set => Set(ref lastName, value);
        }

        private int age;
        public int Age
        {
            get => age;
            set => Set(ref age, value);
        }

        private string position;
        public string Position
        {
            get => position;
            set => Set(ref position, value);
        }

        public ICommand SaveEmployeeCommand { get { return new RelayCommand(SaveEmployee); } }

        private void SaveEmployee()
        {
            var result = EmployeeRepository.AddEmployee(new EmployeeModel
            {
                Age = this.Age,
                Id = new Random().Next(2000).ToString(),
                Name = this.Name,
                Salary = new Random().Next(2000),
                Position = this.Position,
                LastName = LastName

            });
            if (result == "ok")
            {
                App.Current.MainPage.Navigation.PopAsync();
            }

        }
    }
}
