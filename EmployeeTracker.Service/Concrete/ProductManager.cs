using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using EmployeeTracker.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Service.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepo _productRepo;
        public ProductManager(IProductRepo iProduct)
        {
            _productRepo = iProduct;
        }
        public Product AddProduct(Product p)
        {
            return _productRepo.AddProduct(p);
        }

        public void DeleteProductById(int id)
        {
            _productRepo.DeleteProductById(id);
        }

        public Machine GetMachine(int selfId)
        {
            return _productRepo.GetMachine(selfId);
        }

        public Product GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return _productRepo.GetProducts();
        }

        public Product UpdateProduct(Product p)
        {
            return _productRepo.UpdateProduct(p);
        }
    }
}
