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
    public class ExportController : Controller
    {
        //private websiteEntities db = new websiteEntities();
        private websiteEntities2 db2 = new websiteEntities2();

        // GET: Export
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Members_Data()
        {
            return View(db2.Members_Data.ToList());
        }
        public ActionResult login()
        {
            return View(db2.logins.ToList());
        }



       
    }
}
