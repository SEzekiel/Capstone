using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medy.Models;

namespace Medy.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (MedyDBEntities db = new MedyDBEntities())
            {
                List<Employee> emplist = db.Employees.ToList<Employee>();
                return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (MedyDBEntities db = new MedyDBEntities())
                {
                    return View(db.Employees.Where(x => x.employeeID == id).FirstOrDefault<Employee>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (MedyDBEntities db = new MedyDBEntities())
            {
                if (emp.employeeID == 0)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Employee added successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Employee updated successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (MedyDBEntities db = new MedyDBEntities())
            {
                Employee emp = db.Employees.Where(x => x.employeeID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Employee deleted successfully" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}