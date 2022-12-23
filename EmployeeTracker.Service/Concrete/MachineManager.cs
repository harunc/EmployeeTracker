using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using EmployeeTracker.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Concrete
{
    public class MachineManager : IMachineService
    {
        private IMachineRepo _machineRepo;
        public MachineManager(IMachineRepo iMachine)
        {
            _machineRepo = iMachine;
        }
        public Machine AddMachine(Machine m)
        {
            return _machineRepo.AddMachine(m);
        }

        public void DeleteMachineById(int id)
        {
             _machineRepo.DeleteMachineById(id);
        }

        public Machine GetMachineById(int id)
        {
            return _machineRepo.GetMachineById(id);
        }

        public List<Machine> GetMachines()
        {
            return _machineRepo.GetMachines();
        }
        public Employee GetEmployee(int selfId)
        {
            return _machineRepo.GetEmployee(selfId);
        }
        public Machine UpdateMachine(Machine m)
        {
            return _machineRepo.UpdateMachine(m);
        }
    }
}
