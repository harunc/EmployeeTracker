using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeTracker.Core
{
    public class Machine_Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MachineId { get; set; }
        public int ProductId { get; set; }
        public Machine machine { get; set; }
        public Product product { get; set; }
    }
}
