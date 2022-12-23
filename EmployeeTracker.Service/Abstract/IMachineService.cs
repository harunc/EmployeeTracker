using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Abstract
{
    public interface IMachineService
    {
        List<Machine> GetMachines();
        Machine GetMachineById(int id);
        void DeleteMachineById(int id);
        Machine UpdateMachine(Machine m);
        Machine AddMachine(Machine m);
        Employee GetEmployee(int selfId);
    }
}
