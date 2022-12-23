using EmployeeTracker.Core;
using EmployeeTracker.Data;
using EmployeeTracker.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.API.Controllers
{
    [Authorize]
    [Route("/")]
    public class AdminController:ControllerBase
    {
        private IEmployeeService _employeeService;

        public AdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        [AllowAnonymous]
        public ItemForLocalStorage Login([FromBody] Login e)
        {
            ETDbContext db = new ETDbContext();
            var datavalue = db.Employees.FirstOrDefault(x => x.Name == e.Name && x.NumberOfItemsProduced == e.NumberOfItemsProduced);
            Console.WriteLine(datavalue);
            if (datavalue != null)
            {
                ItemForLocalStorage newItem = new ItemForLocalStorage();
                newItem.Id = datavalue.Id;
                newItem.Role = datavalue.Role;
                newItem.Token = datavalue.Token;
                return newItem;
            }
            else
            {
                ItemForLocalStorage newItem = new ItemForLocalStorage();
                newItem.Role = "Not Authorized";
                return newItem;
            }
            }
    }
}
