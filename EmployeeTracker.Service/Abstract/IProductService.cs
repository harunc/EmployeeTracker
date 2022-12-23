using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Abstract
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void DeleteProductById(int id);
        Product UpdateProduct(Product p);
        Product AddProduct(Product p);
        Machine GetMachine(int selfId);
    }
}
