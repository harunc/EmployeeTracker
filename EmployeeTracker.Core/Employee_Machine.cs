using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeTracker.Core
{
    public class Employee_Machine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int MachineId { get; set; }
        public Employee employee { get; set; }
        public Machine machine { get; set; }
    }
}
