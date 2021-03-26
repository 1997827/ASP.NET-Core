using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG_WebApi_Core.IServices;
using CSG_WebApi_Core.Models;
namespace CSG_WebApi_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employee)
        {
            employeeService = employee;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Employee/GetEmployee")]
        public IEnumerable<Status> GetEmployee()
        {
            return employeeService.GetEmployee();
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/Employee/AddEmployee")]
        public Status AddEmployee(Status employee)
        {
            return employeeService.AddEmployee(employee);
        }
        [HttpPut]
        [Route("[action]")]
        [Route("api/Employee/EditEmployee")]
        public Status EditEmployee(Status employee)
        {
            return employeeService.UpdateEmployee(employee);
        }
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Employee/DeleteEmployee")]
        public Status DeleteEmployee(string id)
        {
            return employeeService.DeleteEmployee(id);
        }
        [HttpGet]
        [Route("[action]")]
        [Route("api/Employee/GetEmployeeId")]
        public Status GetEmployeeId(string id)
        {
            return employeeService.GetEmployeeById(id);
        }

    }
}
