using EmployeeTracker.Core;
using EmployeeTracker.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.API.Controllers
{

        [Route("admin/api/[controller]")]
        [ApiController]
        public class EmpmachinesController : ControllerBase
        {
            private IEmployee_MachineService _emService;

            public EmpmachinesController(IEmployee_MachineService emService)
            {
                _emService = emService;
            }

            [HttpGet]
            public List<Employee_Machine> Get()
            {
                return _emService.GetEmployeeMachineConnections();
            }
            [HttpGet("{id}")]
            public Employee_Machine Get(int id)
            {
                return _emService.GetEmployeeMachineConnectionById(id);
            }
            [HttpPost]
            public Employee_Machine Post([FromBody] Employee_Machine em)
            {
                return _emService.AddEmployeeMachineConnection(em
                    );
            }
            [HttpPut]
            public Employee_Machine Put([FromBody] Employee_Machine em)
            {
                return _emService.UpdateEmployeeMachineConnection(em
                    );
            }
            [HttpDelete]
            public void Delete([FromBody] int id)
            {
                _emService.DeleteEmployeeMachineConnectionById(id);
            }

        }
}
