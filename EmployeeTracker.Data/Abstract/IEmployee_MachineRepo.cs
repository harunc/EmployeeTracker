using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Data.Abstract
{
    public interface IEmployee_MachineRepo
    {
        List<Employee_Machine> GetEmployeeMachineConnections();
        Employee_Machine GetEmployeeMachineConnectionById(int id);
        void DeleteEmployeeMachineConnectionById(int id);
        Employee_Machine AddEmployeeMachineConnection(Employee_Machine em);
        Employee_Machine UpdateEmployeeMachineConnection(Employee_Machine em);
    }
}
