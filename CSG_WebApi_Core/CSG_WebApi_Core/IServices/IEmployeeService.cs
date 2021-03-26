using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG_WebApi_Core.Models;
namespace CSG_WebApi_Core.IServices
{
   public interface IEmployeeService
    {
        IEnumerable<Status> GetEmployee();
        Status GetEmployeeById(string id);
        Status AddEmployee(Status employee);
        Status UpdateEmployee(Status employee);
        Status DeleteEmployee(string id);
    }
}
