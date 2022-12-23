using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using EmployeeTracker.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Concrete
{
    public class EmployeeManager : IEmployeeService
    {

        private IEmployeeRepo _employeeRepo;
        public EmployeeManager(IEmployeeRepo iEmployee)
        {
            _employeeRepo = iEmployee;
        }
        public Employee AddEmployee(Employee e)
        {
            return _employeeRepo.AddEmployee(e);
        }


        public void DeleteEmployeeById(int id)
        {
            _employeeRepo.DeleteEmployeeById(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepo.GetEmployees();
        }

        public Machine GetMachine(int selfId)
        {
            return _employeeRepo.GetMachine(selfId);
        }

        public Employee UpdateEmployee(Employee e)
        {
           return _employeeRepo.UpdateEmployee(e);
        }
    }
}
