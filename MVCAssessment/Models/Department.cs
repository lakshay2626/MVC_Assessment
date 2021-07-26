using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAssessment.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }
        [Required]
        public string DptName { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}