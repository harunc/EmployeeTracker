using EmployeeTracker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Data.Abstract
{
    public interface IProductRepo
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void DeleteProductById(int id);
        Product UpdateProduct(Product p);
        Product AddProduct(Product p);
        Machine GetMachine(int selfId);
    }
}
