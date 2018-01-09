using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medy.Models;

namespace Medy.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (InventoryEntity db = new InventoryEntity())
            {
                List<Request> rqlist = db.Requests.ToList<Request>();
                return Json(new { data = rqlist }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Request());
            }
            else
            {
                using (InventoryEntity db = new InventoryEntity())
                {
                    return View(db.Requests.Where(x => x.requestID == id).FirstOrDefault<Request>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Request request)
        {
            using (InventoryEntity db = new InventoryEntity())
            {
                if (request.requestID == 0)
                {
                    db.Requests.Add(request);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Request added successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(request).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Request updated successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (InventoryEntity db = new InventoryEntity())
            {
                Request req = db.Requests.Where(x => x.requestID == id).FirstOrDefault<Request>();
                db.Requests.Remove(req);
                db.SaveChanges();
                return Json(new { success = true, message = "Request deleted successfully" }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}