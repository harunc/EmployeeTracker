using EmployeeTracker.Core;
using EmployeeTracker.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeTracker.Data.Concrete
{
    public class ProductRepo : IProductRepo
    {
        public Product AddProduct(Product p)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Add(p);
                ETDbContext.SaveChanges();
                return p;
            }
        }

        public void DeleteProductById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                Product p = GetProductById(id);
                ETDbContext.Products.Remove(p);
                ETDbContext.SaveChanges();

            }
        }

        public Product GetProductById(int id)
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Products.Find(id);
            }
        }

        public List<Product> GetProducts()
        {
            using (var ETDbContext = new ETDbContext())
            {
                return ETDbContext.Products.ToList();
            }
        }
        public Machine GetMachine(int selfId)
        {
            using (var ETDbContext = new ETDbContext())
            {
                Machine_Product mp = ETDbContext.MachinesAndProducts.Where(res => res.ProductId == selfId).FirstOrDefault();
                Machine m = ETDbContext.Machines.Find(mp.MachineId);
                return m;
            }
        }

        public Product UpdateProduct(Product p)
        {
            using (var ETDbContext = new ETDbContext())
            {
                ETDbContext.Products.Update(p);
                ETDbContext.SaveChanges();
                return p;
            }
        }
    }
}
