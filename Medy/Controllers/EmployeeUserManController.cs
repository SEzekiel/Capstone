using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medy.Models;

namespace Medy.Controllers
{
    public class EmployeeUserManController : Controller
    {
        // GET: EmployeeUserMan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (EmployeeUserManagementModel db = new EmployeeUserManagementModel())
            {
                List<EmployeeUser> emplist = db.EmployeeUsers.ToList<EmployeeUser>();
                return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new EmployeeUser());
            }
            else
            {
                using (EmployeeUserManagementModel db = new EmployeeUserManagementModel())
                {
                    return View(db.EmployeeUsers.Where(x => x.userID == id).FirstOrDefault<EmployeeUser>());
                }
            }
        }

        [HttpPost]
        public ActionResult Add(EmployeeUser empuser)
        {
            using (EmployeeUserManagementModel db = new EmployeeUserManagementModel())
            {
                if (empuser.userID == 0)
                {
                    db.EmployeeUsers.Add(empuser);
                    db.SaveChanges();
                    return Json(new { success = true, message = "New user added successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(empuser).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "User updated successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (EmployeeUserManagementModel db = new EmployeeUserManagementModel())
            {
                EmployeeUser empuser = db.EmployeeUsers.Where(x => x.userID == id).FirstOrDefault<EmployeeUser>();
                db.EmployeeUsers.Remove(empuser);
                db.SaveChanges();
                return Json(new { success = true, message = "Employee deleted successfully" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}