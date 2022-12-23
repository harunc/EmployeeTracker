using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace EmployeeTracker.Data.Concrete
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public Employee AddEmployee(Employee e)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Employees.Add(e);
                ETDbContext.SaveChanges();
                return e;
            }
        }


        public void DeleteEmployeeById(int id)
        {
            
            using (var ETDbContext=new ETDbContext())
            {
                Employee e = GetEmployeeById(id);
                ETDbContext.Employees.Remove(e);
                ETDbContext.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using(var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Employees.Find(id);
            }
        }

        public List<Employee> GetEmployees()
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Employees.ToList();
            }
        }

        public Machine GetMachine(int selfId)
        {
            using(var ETDbContext = new ETDbContext())
            {
                Employee_Machine em = ETDbContext.EmployeeAndMachines.Where(res => res.EmployeeId == selfId).FirstOrDefault();
                Machine m = ETDbContext.Machines.Find(em.MachineId);
                return m;

            }
        }

        public Employee UpdateEmployee(Employee e)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Employees.Update(e);
                ETDbContext.SaveChanges();
                return e;
            }
        }
    }
}
