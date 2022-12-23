using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using EmployeeTracker.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Concrete
{
    public class E_MConnectionManager : IEmployee_MachineService
    {
        private IEmployee_MachineRepo _emConnectionRepo;
        public E_MConnectionManager(IEmployee_MachineRepo iEMConnection)
        {
            _emConnectionRepo = iEMConnection;
        }
        public Employee_Machine AddEmployeeMachineConnection(Employee_Machine em)
        {
            return _emConnectionRepo.AddEmployeeMachineConnection(em);
        }

        public void DeleteEmployeeMachineConnectionById(int id)
        {
            _emConnectionRepo.DeleteEmployeeMachineConnectionById(id);
        }

        public Employee_Machine GetEmployeeMachineConnectionById(int id)
        {
            return _emConnectionRepo.GetEmployeeMachineConnectionById(id);
        }

        public List<Employee_Machine> GetEmployeeMachineConnections()
        {
            return _emConnectionRepo.GetEmployeeMachineConnections();
        }

        public Employee_Machine UpdateEmployeeMachineConnection(Employee_Machine em)
        {
            return _emConnectionRepo.UpdateEmployeeMachineConnection(em);
        }
    }
}
