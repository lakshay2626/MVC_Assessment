using MVCAssessment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAssessment
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOJ { get; set; }
        [Required]
        public int Mobile { get; set; }
        [EmailAddress(ErrorMessage ="plese enter valid email address")]
        public string Email { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public Salary Salary { get; set; }
    }
}