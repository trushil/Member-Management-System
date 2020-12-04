using CrystalDecisions.CrystalReports.Engine;
using surathardwarewebsite.Models;
using surathardwarewebsite.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace surathardwarewebsite.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        
        private websiteEntities db = new websiteEntities();
        private websiteEntities2 db2 = new websiteEntities2();
        // GET: Account
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ChangePassword_Successfull()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        public ActionResult Edit_Profile(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit_Profile(Members_Dealing data)
        {
            if (ModelState.IsValid)
            {
                data.Membership_Id = User.Identity.Name;
                db2.Entry(data).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("Account_details");
            }
            return View();
        }


        public ActionResult exportReport()
        {


            datum datum = db.data.Find(User.Identity.Name);

            return View();

            //CrystalReport rd = new CrystalReport();

            //var results = (from obj in db.data
            //               where obj.Id == User.Identity.Name
            //               select new { obj.c_person1_Name, obj.c_person2_Name, obj.Id }).ToList();
            //rd.Load(Path.Combine(Server.MapPath("~/Reporting"), "CrystalReport.rpt"));
            
            //rd.SetDataSource(results);
            
            //Response.Buffer = false;
            //Response.ClearContent();
            //Response.ClearHeaders();
            
            //try
            //{
            //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //    stream.Seek(0, SeekOrigin.Begin);
            //    return File(stream, "application/pdf", "Certificate.pdf");

            //}
            //catch
            //{
            //    throw;
            //}

        }

        public ActionResult change()
        {
            login login = db2.logins.Find(User.Identity.Name);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult change( login login)
        {
            if (ModelState.IsValid)
            {
                
                db2.Entry(login).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("ChangePassword_Successfull");
            }
            return View(login);



        }

        public ActionResult Account_details(string id)
        {
            if(User.Identity.IsAuthenticated)
            {
                
                Members_Data data = db2.Members_Data.Find(User.Identity.Name);
                Members_Dealing data2 = db2.Members_Dealing.Find(User.Identity.Name);
                websiteEntities2 mymodel = new websiteEntities2();

                string path = "~/Content/UserAccount_Profile_Photos/" + data.Membership_Id + ".jpg";
                var absolutePath = HttpContext.Server.MapPath(path);
                if (System.IO.File.Exists(absolutePath))
                {
                    ViewBag.ProfilephotoPath = data.Membership_Id + ".jpg";
                    ViewBag.profilepicpresent = "true";
                }
                else
                {
                    ViewBag.ProfilephotoPath = "unnamed.png";
                    ViewBag.profilepicpresent = "false";
                }
                ViewBag.MData = data;
                ViewBag.MDealing = data2;
                //ViewBag.ProfilephotoPath = data.Membership_Id + ".jpg";
                
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }


        }

        [HttpPost]
        public ActionResult Login(login U)
        {

            var count = db2.logins.Where(x => x.Username == U.Username && x.Password == U.Password).Count();

            if (count == 0)
            {
                ViewBag.Msg = "Incorrect Username/Password. Please try again!";
                //ModelState.AddModelError("name", "Incorrect Username/Password. Please try again!");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.Username, false);
                return RedirectToAction("Index", "Home");

            }

        }

        [HttpPost]
        public ActionResult Generate_Certificate(datum d)
        {
            var name = d.Name;

            CrystalReport rd = new CrystalReport();

            rd.Load(Path.Combine(Server.MapPath("~/Reporting"), "CrystalReport.rpt"));

            //rd.SetDataSource(results);
            rd.SetParameterValue("", d.Name);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Certificate.pdf");

            }
            catch
            {
                throw;
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}