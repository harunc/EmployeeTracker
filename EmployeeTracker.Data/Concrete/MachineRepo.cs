using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTracker.Data.Concrete
{
    public class MachineRepo : IMachineRepo
    {
        public Machine AddMachine(Machine m)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Add(m);
                ETDbContext.SaveChanges();
                return m;
            }
        }

        public void DeleteMachineById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                Machine m = GetMachineById(id);
                ETDbContext.Machines.Remove(m);
                ETDbContext.SaveChanges();

            }
        }

        public Machine GetMachineById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Machines.Find(id);
            }
        }

        public List<Machine> GetMachines()
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Machines.ToList();
            }
        }
        public Employee GetEmployee(int selfId)
        {
            using(var ETDbContext=new ETDbContext()) {
               Employee_Machine me = ETDbContext.EmployeeAndMachines.Where(res => res.MachineId == selfId).FirstOrDefault();
               Employee e = ETDbContext.Employees.Find(me.EmployeeId);
               return e;
            }
        }

        public Machine UpdateMachine(Machine m)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Machines.Update(m);
                ETDbContext.SaveChanges();
                return m;
            }
        }
    }
}
