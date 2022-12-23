using EmployeeTracker.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeTracker.Data
{
    public class ETDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer("Server=DESKTOP-HVEJO59;Database=EmployeeTrackerDB;uid=sa;pwd=1234; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee_Machine>().HasKey(pc => new { pc.EmployeeId, pc.MachineId });
            modelBuilder.Entity<Employee_Machine>()
                .HasOne(e => e.employee).WithMany(em => em.Employee_Machine).HasForeignKey(ei => ei.EmployeeId);
            modelBuilder.Entity<Employee_Machine>()
                .HasOne(m => m.machine).WithMany(me => me.Employee_Machine).HasForeignKey(mi => mi.MachineId);
            modelBuilder.Entity<Machine_Product>()
                .HasOne(p => p.product).WithMany(pm => pm.Machine_Product).HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<Machine_Product>()
                .HasOne(m => m.machine).WithMany(mp => mp.Machine_Product).HasForeignKey(mi => mi.MachineId);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Employee_Machine> EmployeeAndMachines { get; set; }
        public DbSet<Machine_Product> MachinesAndProducts { get; set; }
    }
}
