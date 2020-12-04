using CrystalDecisions.CrystalReports.Engine;
using surathardwarewebsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace surathardwarewebsite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        websiteEntities db = new websiteEntities();
        private websiteEntities2 db2 = new websiteEntities2();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                List<SelectListItem> Service_To_Others = new List<SelectListItem>()
            {
                new SelectListItem {Text = "No", Value = "No"},
                new SelectListItem {Text = "Yes", Value = "Yes"},
            };
                List<SelectListItem> Trading_Pattern = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Retail", Value = "Retail"},
                new SelectListItem {Text = "Wholesale", Value = "Wholesale"},
            };

                List<SelectListItem> Firm_Type = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Partner", Value = "Partner"},
                new SelectListItem {Text = "Proprietor", Value = "Proprietor"},
            };

                List<SelectListItem> Area = new List<SelectListItem>()
            {
                new SelectListItem {Text = "A K Road", Value = "A K Road"},
                new SelectListItem {Text = "Adajan", Value = "Adajan"},
                new SelectListItem {Text = "Amroli", Value = "Amroli"},
                new SelectListItem {Text = "Bamroli", Value = "Bamroli"},
                new SelectListItem {Text = "Bhagal", Value = "Bhagal"},
                new SelectListItem {Text = "Bhatar", Value = "Bhatar"},
                new SelectListItem {Text = "Bhathena", Value = "Bhathena"},
                new SelectListItem {Text = "City Light", Value = "City Light"},
                new SelectListItem {Text = "Dindoli", Value = "Dindoli"},
                new SelectListItem {Text = "Dumas", Value = "Ghod Dod Road"},
                new SelectListItem {Text = "Ghod Dod Road", Value = "Ghod Dod Road"},
                new SelectListItem {Text = "Godadara", Value = "Godadara"},
                new SelectListItem {Text = "Hazira", Value = "Hazira"},
                new SelectListItem {Text = "Jangirabad", Value = "Jangirabad"},
                new SelectListItem {Text = "Kadodara", Value = "Kadodara"},
                new SelectListItem {Text = "Kamrej", Value = "Kamrej"},
                new SelectListItem {Text = "Katargam", Value = "Katargam"},
                new SelectListItem {Text = "Kotsaffil", Value = "Kotsaffil"},
                new SelectListItem {Text = "L H Road", Value = "L H Road"},
                new SelectListItem {Text = "Limbayat", Value = "Limbayat"},
                new SelectListItem {Text = "Majura Gate", Value = "Majura Gate"},
                new SelectListItem {Text = "Nana Varaccha", Value = "Nana Varaccha"},
                new SelectListItem {Text = "Nanpura", Value = "Nanpura"},
                new SelectListItem {Text = "Out City", Value = "Out City"},
                new SelectListItem {Text = "P K Road", Value = "P K Road"},
                new SelectListItem {Text = "Pal Gam", Value = "Pal Gam"},
                new SelectListItem {Text = "Pal Road", Value = "Pal Road"},
                new SelectListItem {Text = "Palanpur Gam", Value = "Palanpur Gam"},
                new SelectListItem {Text = "Palanpur Jakatnaka", Value = "Palanpur Jakatnaka"},
                new SelectListItem {Text = "Pandesara", Value = "Pandesara"},
                new SelectListItem {Text = "Pandesara Road", Value = "Pandesara Road"},
                new SelectListItem {Text = "Parle Point", Value = "Parle Point"},
                new SelectListItem {Text = "Parvat Patiya", Value = "Parvat Patiya"},
                new SelectListItem {Text = "Punagam", Value = "Punagam"},
                new SelectListItem {Text = "Raika Circle", Value = "Raika Circle"},
                new SelectListItem {Text = "Raj Marg", Value = "Raj Marg"},
                new SelectListItem {Text = "Rander", Value = "Rander"},
                new SelectListItem {Text = "Ring Road", Value = "Ring Road"},
                new SelectListItem {Text = "Rustampura", Value = "Rustampura"},
                new SelectListItem {Text = "Sachin", Value = "Sachin"},
                new SelectListItem {Text = "Saiyedpura", Value = "Saiyedpura"},
                new SelectListItem {Text = "Saroli", Value = "Saroli"},
                new SelectListItem {Text = "Simada", Value = "Simada"},
                new SelectListItem {Text = "Station Road", Value = "Station Road"},
                new SelectListItem {Text = "Surat Station", Value = "Surat Station"},
                new SelectListItem {Text = "Tower Police Gate", Value = "Tower Police Gate"},
                new SelectListItem {Text = "Tower Road", Value = "Tower Road"},
                new SelectListItem {Text = "U M Road", Value = "U M Road"},
                new SelectListItem {Text = "Udhna", Value = "Udhna"},
                new SelectListItem {Text = "Utran", Value = "Utran"},
                new SelectListItem {Text = "V R Hirabaugh", Value = "V R Hirabaugh"},
                new SelectListItem {Text = "V R Main Road", Value = "V R Main Road"},
                new SelectListItem {Text = "V R Mota Varaccha", Value = "V R Mota Varaccha"},
                new SelectListItem {Text = "V R Nana Varaccha", Value = "V R Nana Varaccha"},
                new SelectListItem {Text = "V R Simada", Value = "V R Simada"},
                new SelectListItem {Text = "Varachha", Value = "Varachha"},
                new SelectListItem {Text = "Ved Road", Value = "Ved Road"},
                new SelectListItem {Text = "Vesu", Value = "Vesu"},
                new SelectListItem {Text = "Yogi Chowk", Value = "Yogi Chowk"},
            };

                List<SelectListItem> Zone = new List<SelectListItem>()
            {
                new SelectListItem {Text = "South West Zone", Value = "South West Zone"},
                new SelectListItem {Text = "South Zone", Value = "South Zone"},
                new SelectListItem {Text = "Central Zone", Value = "Central Zone"},
                new SelectListItem {Text = "West Zone", Value = "West Zone"},
                new SelectListItem {Text = "North Zone", Value = "North Zone"},
                new SelectListItem {Text = "East Zone", Value = "East Zone"},

            };

                List<SelectListItem> Blood_Group = new List<SelectListItem>()
            {
                new SelectListItem {Text = "A+", Value = "A+"},
                new SelectListItem {Text = "A-", Value = "A-"},
                new SelectListItem {Text = "B+", Value = "B+"},
                new SelectListItem {Text = "B-", Value = "B-"},
                new SelectListItem {Text = "O+", Value = "O+"},
                new SelectListItem {Text = "O-", Value = "O-"},
                new SelectListItem {Text = "AB+", Value = "AB+"},
                new SelectListItem {Text = "AB-", Value = "AB-"},

            };

                ViewData["Service_To_Others_DropDown"] = Service_To_Others;
                ViewData["Trading_Pattern_DropDown"] = Trading_Pattern;
                ViewData["Firm_Type_DropDown"] = Firm_Type;
                ViewData["Area_DropDown"] = Area;
                ViewData["Zone_DropDown"] = Zone;
                ViewData["Blood_Group_DropDown"] = Blood_Group;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Request Request)
        {
            if (ModelState.IsValid)
            {
                
                Request.Request_Id = Get_Request_Id(); //get new Membership_ID
                Request.Request_Type = "New Sign Up";
                Request.Request_From = User.Identity.Name;
                Request.Request_To = "Admin";
                Request.Request_Date = DateTime.Today.ToShortDateString();
                Request.Request_Status = "Submitted";
                db2.Requests.Add(Request);

                db2.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Request);
        }

        private String Get_Request_Id()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            finalString = "RQ-" + finalString;
            //Members_Data d = db2.Members_Data.Find(finalString);
            var count1 = db2.Requests.Where(x => x.Request_Id == finalString).Count();
            if (count1 == 0)
            {
                return finalString;
            }
            else
            {
                return Get_Request_Id();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( login login)
        {
            login.Role = "x";
            var count = db2.logins.Where(x => x.Username == login.Username && x.Password == login.Password).Count();
            if (ModelState.IsValid && count==0)
            {
                db.logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Login","Account");
            }

            else
            {
                
                ModelState.AddModelError("name", "The Username is already taken. Please choose different Username!");
            }
            

            return View();
        }

        public ActionResult Gallery_AGM_2()
        {
            return View();
        }

        public ActionResult Gallery_AGM_3()
        {
            return View();
        }

        public ActionResult Gallery_AGM_5()
        {
            return View();
        }

        public ActionResult Gallery_AGM_6()
        {
            return View();
        }
        public ActionResult Gallery_AGM_7()
        {
            return View();
        }

        public ActionResult Gallery_AGM_8()
        {
            return View();
        }
        public ActionResult Gallery_AGM_9()
        {
            return View();
        }
        public ActionResult Blood_Donation_2020()
        {

            return View();
        }
        public ActionResult Future_Of_Retail_Trade()
        {

            return View();
        }
        public ActionResult Mega_Build_Expo_2020()
        {

            return View();
        }
        public ActionResult Natak()
        {

            return View();
        }
        public ActionResult Opening_Ceremony()
        {

            return View();
        }
        public ActionResult Cricket_Tournament_2019()
        {

            return View();
        }
    }
}