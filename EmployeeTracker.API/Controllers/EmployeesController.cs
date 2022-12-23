using EmployeeTracker.Core;
using EmployeeTracker.Service.Abstract;
using EmployeeTracker.Service.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.API.Controllers
{
    [Route("admin/api/[controller]")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Authorize(Policy = "RolePolicy")]
        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee e = _employeeService.GetEmployeeById(id);
            Console.WriteLine("Hello");
            return e;
        }
        [HttpGet("{id}/machine")]
        public Machine GetMachine(int id)
        {
            Machine m = _employeeService.GetMachine(id);
            
            return m;
        }

        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            return _employeeService.AddEmployee(employee
                );
        }
        [HttpPut]
        public Employee Put([FromBody] Employee employee)
        {
            return _employeeService.UpdateEmployee(employee
                );
        }
        [HttpPut("{id}/{stats}")]
        public Employee ChangeStatus(int id,string stats)
        {
            Employee e = _employeeService.GetEmployeeById(id);
            if (stats == "idle")
            {
                e.Status = 2;
            }
            else if(stats == "working")
            {
                e.Status = 1;            }
            else if (stats == "finished")
            {
                e.Status = 0;
            }
            else
            {
                throw new Exception("worker status couldn't be changed");
            }
                return _employeeService.UpdateEmployee(e
                    );
        }
        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            _employeeService.DeleteEmployeeById(id);
        }

    }


}
