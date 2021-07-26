using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAssessment;
using MVCAssessment.Models;
using System.Linq;

namespace MVCAssessment.Controllers
{
    public class EmployeesController : Controller
    {
        ContextFile _contextFile;

       
        public ActionResult Index()
        {
            List<Employee> employees;
            using (_contextFile = new ContextFile())
            {
                employees = _contextFile.Employees.Include(e => e.Department).Include(e => e.Salary).ToList();
            }

            var orderedList = from e in employees
                              orderby e.Salary.SalaryAmount descending, e.Name
                              select e;
            return View(orderedList);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Employee employee )
        {
            if (ModelState.IsValid)
            {
                using (_contextFile = new ContextFile())
                {
                    _contextFile.Employees.Add(employee);
                    _contextFile.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            return View(employee);
        }

       
        public ActionResult Edit(int id)
        {
            Employee employee;
            using (_contextFile = new ContextFile())
            {
               employee = _contextFile.Employees.Include("Department").Include("Salary").FirstOrDefault( o => o.EmployeeId == id );
            }
            
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using(_contextFile = new ContextFile())
                {
                    Employee savedEmployee = _contextFile.Employees.Include("Salary").FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                    savedEmployee.Name = employee.Name;
                    savedEmployee.DOJ = employee.DOJ;
                    savedEmployee.DeptId = employee.DeptId;
                    savedEmployee.Email = employee.Email;
                    savedEmployee.Address = employee.Address;
                    savedEmployee.Mobile = employee.Mobile;
                    savedEmployee.Salary.SalaryAmount = employee.Salary.SalaryAmount;

                    _contextFile.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
           
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            using (_contextFile = new ContextFile())
            {
                Employee employee = _contextFile.Employees.Find(id);
                _contextFile.Employees.Remove(employee);
                _contextFile.SaveChanges();
            }
               
            return RedirectToAction("Index");
        }
      
    }
}
