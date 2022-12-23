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
    public class ProductsController:ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService machineService)
        {
            _productService = machineService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productService.GetProducts();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id);
        }
        [HttpGet("{id}/employee")]
        public Machine GetEmployee(int id)
        {
            return _productService.GetMachine(id);
        }
        [HttpPost]
        public Product Post([FromBody] Product machine)
        {
            return _productService.AddProduct(machine
                );
        }
        [HttpPut]
        public Product Put([FromBody] Product machine)
        {
            return _productService.UpdateProduct(machine
                );
        }
        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            _productService.DeleteProductById(id);
        }

    }
}