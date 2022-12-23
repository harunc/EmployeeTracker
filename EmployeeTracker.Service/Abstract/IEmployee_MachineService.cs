using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Abstract
{
    public interface IEmployee_MachineService
    {
        List<Employee_Machine> GetEmployeeMachineConnections();
        Employee_Machine GetEmployeeMachineConnectionById(int id);
        void DeleteEmployeeMachineConnectionById(int id);
        Employee_Machine AddEmployeeMachineConnection(Employee_Machine em);
        Employee_Machine UpdateEmployeeMachineConnection(Employee_Machine em);
    }
}
