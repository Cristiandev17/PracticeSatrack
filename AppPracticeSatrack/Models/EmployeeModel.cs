using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPracticeSatrack.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }

        public int Salary { get; set; }

        public string NameComplete => $"{Name} {LastName}";
        
    }
}
