using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using IT18540536_api.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Data.SqlClient;
using IT18540536_api.Data;

namespace IT18540536_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationdbcontext;
        public EmployeeController(ApplicationDbContext applicationdbcontext)
        {
            _applicationdbcontext = applicationdbcontext;
        }

        //get all data
        [HttpGet]
        public JsonResult Get()
        {
            List<Employee> employees = _applicationdbcontext.Employee.ToList();
            return new JsonResult(employees);
        }

        //insert data
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            var employee = _applicationdbcontext.Employee.FirstOrDefault(m => m.EmployeeId == emp.EmployeeId);
            if (employee != null)
            {
                return new JsonResult("Already Exists");
            }
            _applicationdbcontext.Employee.Add(emp);
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Added Successfully");
        }

        //update data
        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            var employee = _applicationdbcontext.Employee.FirstOrDefault(m => m.EmployeeId == emp.EmployeeId);
            if (employee == null)
            {
                return new JsonResult("Not Found");
            }
            employee.EmployeeName = emp.EmployeeName;
            employee.Department = emp.Department;
            employee.DateOfJoining = emp.DateOfJoining;
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Updated Successfully");
        }

        //delete data
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var employee = _applicationdbcontext.Employee.FirstOrDefault(m => m.EmployeeId == id);
            if(employee == null)
            {
                return new JsonResult("Not Found");
            }
            _applicationdbcontext.Employee.Remove(employee);
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Removed Successfully");
        }

    }
}