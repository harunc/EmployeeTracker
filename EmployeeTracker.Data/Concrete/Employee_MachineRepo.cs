using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTracker.Data.Concrete
{
    public class Employee_MachineRepo : IEmployee_MachineRepo
    {
        public Employee_Machine AddEmployeeMachineConnection(Employee_Machine em)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.EmployeeAndMachines.Add(em);
                ETDbContext.SaveChanges();
                return em;
            }
        }

        public void DeleteEmployeeMachineConnectionById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                Employee_Machine em = GetEmployeeMachineConnectionById(id);
                ETDbContext.EmployeeAndMachines.Remove(em);
                ETDbContext.SaveChanges();
            }
        }

        public Employee_Machine GetEmployeeMachineConnectionById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.EmployeeAndMachines.Find(id);
            }
        }

        public List<Employee_Machine> GetEmployeeMachineConnections()
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.EmployeeAndMachines.ToList();
            }
        }

        public Employee_Machine UpdateEmployeeMachineConnection(Employee_Machine em)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.EmployeeAndMachines.Update(em);
                ETDbContext.SaveChanges();
                return em;
            }
        }
    }
}
