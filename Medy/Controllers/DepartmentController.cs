using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medy.Models;

namespace Medy.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DepartmentEntity db = new DepartmentEntity())
            {
                List<department> emplist = db.departments.ToList<department>();
                return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {
                return View(new department());
            }
            else
            {
                using (DepartmentEntity db = new DepartmentEntity())
                {
                    return View(db.departments.Where(x => x.departmentID == id).FirstOrDefault<department>());
                }
            }
        }

        [HttpPost]
        public ActionResult Add(department dpt)
        {
            using (DepartmentEntity db = new DepartmentEntity())
            {
                if (dpt.departmentID == 0)
                {
                    db.departments.Add(dpt);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Department added successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(dpt).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Department updated successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DepartmentEntity db = new DepartmentEntity())
            {
                department emp = db.departments.Where(x => x.departmentID == id).FirstOrDefault<department>();
                db.departments.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Department deleted successfully" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}