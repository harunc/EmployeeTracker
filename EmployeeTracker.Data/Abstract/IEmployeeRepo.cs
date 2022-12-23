using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Data.Abstract
{
    public interface IEmployeeRepo
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void DeleteEmployeeById(int id);
        Employee AddEmployee(Employee e);
        Employee UpdateEmployee(Employee e);
        Machine GetMachine(int selfId);

    }
}
