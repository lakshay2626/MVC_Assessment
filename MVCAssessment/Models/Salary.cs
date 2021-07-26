using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAssessment.Models
{
    public class Salary
    {
        [Key]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public int SalaryAmount { get; set; }
        public Employee Employee { get; set; }

    }
}