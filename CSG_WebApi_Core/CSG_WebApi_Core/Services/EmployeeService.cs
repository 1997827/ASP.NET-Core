using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSG_WebApi_Core.Models;
using CSG_WebApi_Core.IServices;
using Microsoft.EntityFrameworkCore;

namespace CSG_WebApi_Core.Services
{
    public class EmployeeService : IEmployeeService
    {

        CSG_InterviewContext dbContext;
        public EmployeeService(CSG_InterviewContext _db)
        {
            dbContext = _db;
        }

       
        public IEnumerable<Status> GetEmployee()
        {
            var employee = dbContext.Statuses.ToList();
            return employee;
        }

        public Status AddEmployee(Status employee)
        {
            if (employee != null)
            {
                dbContext.Statuses.Add(employee);
                dbContext.SaveChanges();
                return employee;
            }
            return null;
        }
        public Status UpdateEmployee(Status employee)
        {
            dbContext.Entry(employee).State = EntityState.Modified;
            dbContext.SaveChanges();
            return employee;
        }
        public Status DeleteEmployee(string id)
        {
            var employee = dbContext.Statuses.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(employee).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return employee;
        }
        public Status GetEmployeeById(string id)
        {
            var employee = dbContext.Statuses.FirstOrDefault(x => x.Id == id);
            return employee;
        }
    }
}
