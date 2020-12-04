using surathardwarewebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace surathardwarewebsite.Controllers
{
    public class RequestsController : Controller
    {
        private websiteEntities2 db2 = new websiteEntities2();

        // GET: Requests
        public ActionResult AdminView()
        {
            return View(db2.Requests.ToList());
        }
        public ActionResult Index()
        {
            return View(db2.Requests.Where(x => x.Request_From == User.Identity.Name).ToList());
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request Request = db2.Requests.Find(id);
            if (Request == null)
            {
                return HttpNotFound();
            }
            return View(Request);
        }
    }
}