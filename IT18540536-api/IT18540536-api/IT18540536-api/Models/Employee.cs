using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT18540536_api.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
