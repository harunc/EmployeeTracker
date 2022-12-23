using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeTracker.Core
{
    public class Machine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public List<Employee_Machine> Employee_Machine { get; set; }
        public List<Machine_Product> Machine_Product { get; set; }
    }
}
