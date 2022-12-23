using EmployeeTracker.Core;
using EmployeeTracker.Service.Abstract;
using EmployeeTracker.Service.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.API.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private IMachineService _machineService;

        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public List<Machine> Get()
        {
            return _machineService.GetMachines();
        }
        [HttpGet("{id}")]
        public Machine Get(int id)
        {
            return _machineService.GetMachineById(id);
        }
        [HttpGet("{id}/employee")]
        public Employee GetEmployee(int id)
        {
            return _machineService.GetEmployee(id);
        }
        [HttpPost]
        public Machine Post([FromBody] Machine machine)
        {
            return _machineService.AddMachine(machine
                );
        }
        [HttpPut]
        public Machine Put([FromBody] Machine machine)
        {
            return _machineService.UpdateMachine(machine
                );
        }
        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            _machineService.DeleteMachineById(id);
        }

    }
}
