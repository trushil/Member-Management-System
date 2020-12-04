using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using surathardwarewebsite.Models;

namespace surathardwarewebsite.Controllers
{
    public class UsersController : Controller
    {
        private websiteEntities db = new websiteEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.logins.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            List<SelectListItem> Role_Type = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Admin", Value = "a"},
                new SelectListItem {Text = "Member", Value = "v"},
                new SelectListItem {Text = "Viewer", Value = "x"},
            };

            ViewData["Roles"] = Role_Type;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(login login)
        {
            if (ModelState.IsValid)
            {
                db.logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,ConfirmPassword,Role")] login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            login login = db.logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            login login = db.logins.Find(id);
            db.logins.Remove(login);
            db.SaveChanges();
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
