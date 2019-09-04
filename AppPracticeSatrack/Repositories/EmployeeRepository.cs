using AppPracticeSatrack.Models;
using AppPracticeSatrack.Models.Response;
using Newtonsoft.Json;
using Ninject.Modules;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Repositories
{
    public static class EmployeeRepository
    {
        private static RestClient _restClient;
        public static RestClient GetRestInstance()
        {
            if (_restClient == null)
            {
                _restClient = new RestClient("https://employeesappapi.azurewebsites.net/");
            }
            return _restClient;
        }

        public static ObservableCollection<EmployeeModel> GetEmployees()
        {
            var listDetail = new ObservableCollection<EmployeeModel>();
            var client = GetRestInstance();
            var request = new RestRequest("api/Employees", Method.GET);
            try
            {
                var response = client.Execute<List<EmployeeResponse>>(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    listDetail = MapModel(response.Data);
                }
            }
            catch (Exception ex)
            {
            }
            return listDetail;
        }



        public static string AddEmployee(EmployeeModel employee)
        {
            var result = string.Empty;
            var client = GetRestInstance();
            var request = new RestRequest("api/Employees", Method.POST);
            var json = JsonConvert.SerializeObject(employee);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return result = "ok";
            }
            else
                return result = "bad";

        }

        public static string DeleteEmployee(string Id)
        {
            var result = string.Empty;
            var client = GetRestInstance();
            var request = new RestRequest("api/Employees", Method.DELETE);
            request.AddParameter("text/json", Id, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return result = "ok";
                }
                else
                    return result = "bad";
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private static ObservableCollection<EmployeeModel> MapModel(List<EmployeeResponse> data)
        {
            ObservableCollection<EmployeeModel> listEmployees = new ObservableCollection<EmployeeModel>();
            foreach (var item in data)
            {
                listEmployees.Add(new EmployeeModel()
                {
                    Id = item.Id,
                    Age = item.Age,
                    Name = item.Name,
                    LastName = item.LastName,
                    Position = item.Position,
                    Salary = item.Salary,
                });
            }
            return listEmployees;
        }
    }
}
