using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeTracker.Core
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Token { get; set; }
        [StringLength(20)]
        public string Role { get; set; }
        public int Status { get; set; }
        public int NumberOfItemsProduced { get; set; }
        public List<Employee_Machine> Employee_Machine { get; set; }
    }
}
