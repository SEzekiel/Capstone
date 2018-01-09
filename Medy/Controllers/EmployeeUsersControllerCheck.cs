using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medy.Models;

namespace Medy.Controllers
{
    public class EmployeeUsersControllerCheck : Controller
    {
        private EmployeeUserManagementModel db = new EmployeeUserManagementModel();

        // GET: EmployeeUsersControllerCheck
        public async Task<ActionResult> Index()
        {
            return View(await db.EmployeeUsers.ToListAsync());
        }

        // GET: EmployeeUsersControllerCheck/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUser employeeUser = await db.EmployeeUsers.FindAsync(id);
            if (employeeUser == null)
            {
                return HttpNotFound();
            }
            return View(employeeUser);
        }

        // GET: EmployeeUsersControllerCheck/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeUsersControllerCheck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "userID,fname,lname,username,email,password")] EmployeeUser employeeUser)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeUsers.Add(employeeUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeUser);
        }

        // GET: EmployeeUsersControllerCheck/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUser employeeUser = await db.EmployeeUsers.FindAsync(id);
            if (employeeUser == null)
            {
                return HttpNotFound();
            }
            return View(employeeUser);
        }

        // POST: EmployeeUsersControllerCheck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "userID,fname,lname,username,email,password")] EmployeeUser employeeUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeUser);
        }

        // GET: EmployeeUsersControllerCheck/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUser employeeUser = await db.EmployeeUsers.FindAsync(id);
            if (employeeUser == null)
            {
                return HttpNotFound();
            }
            return View(employeeUser);
        }

        // POST: EmployeeUsersControllerCheck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeUser employeeUser = await db.EmployeeUsers.FindAsync(id);
            db.EmployeeUsers.Remove(employeeUser);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
