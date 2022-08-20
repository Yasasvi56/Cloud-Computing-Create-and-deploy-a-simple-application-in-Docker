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
using Microsoft.Data.SqlClient;
using IT18540536_api.Data;

namespace IT18540536_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationdbcontext;
        public DepartmentController(IConfiguration configuration, ApplicationDbContext applicationdbcontext)
        {
            _configuration = configuration;
            _applicationdbcontext = applicationdbcontext;
        }

        //get all data
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_applicationdbcontext.Department.ToList());
        }

        //insert data
        [HttpPost]
        public JsonResult Post(Department dep)
        {
            var department = _applicationdbcontext.Department.FirstOrDefault(m => m.DepartmentId == dep.DepartmentId);
            if (department != null)
            {
                return new JsonResult("Already Exists");
            }
            _applicationdbcontext.Department.Add(dep);
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Added Successfully");
        }

        //update data
        [HttpPut]
        public JsonResult Put(Department dep)
        {
            var department = _applicationdbcontext.Department.FirstOrDefault(m => m.DepartmentId == dep.DepartmentId);
            if (department == null)
            {
                return new JsonResult("Not Found");
            }
            department.DepartmentName = dep.DepartmentName;
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Updated Successfully");
        }

        //delete data
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var department = _applicationdbcontext.Department.FirstOrDefault(m => m.DepartmentId == id);
            if(department == null)
            {
                return new JsonResult("Not Found");
            }
            _applicationdbcontext.Department.Remove(department);
            _applicationdbcontext.SaveChanges();
            return new JsonResult("Removed Successfully");
        }
    }
}