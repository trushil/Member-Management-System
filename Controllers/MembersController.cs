using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using surathardwarewebsite.Models;
using System.IO;
using System.Net.Mail;
using MySql.Data.MySqlClient.Memcached;

namespace surathardwarewebsite.Controllers
{
    public class MembersController : Controller
    {

        private websiteEntities2 db2 = new websiteEntities2();

        // GET: Members
        public ActionResult Index()
        {
            return View(db2.Members_Data.ToList());
        }

        

        // GET: Members/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //datum datum = db.data.Find(id);
            //if (datum == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(datum);

            Members_Data data = db2.Members_Data.Find(id);
            Members_Dealing data2 = db2.Members_Dealing.Find(id);
            websiteEntities2 mymodel = new websiteEntities2();

            ViewBag.MData = data;
            ViewBag.MDealing = data2;

            string path = "~/Content/UserAccount_Profile_Photos/" + data.Membership_Id + ".jpg";
            var absolutePath = HttpContext.Server.MapPath(path);

            if (System.IO.File.Exists(absolutePath))
            {
                ViewBag.ProfilephotoPath = data.Membership_Id + ".jpg";
                ViewBag.condition = "true";
            }
            else
            {
                ViewBag.ProfilephotoPath = "unnamed.png";
                ViewBag.condition = "false";
            }
            
            //ViewBag.ProfilephotoPath = data.Membership_Id + ".jpg";

            return View();

        }

        // GET: Members/Create
        public ActionResult Create()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/UserAccount_Profile_Photos/"),Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Members_Data data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        data.Registered_By = "Admin";
        //        data.Membership_Id = Get_Membership_Id(); //get new Membership_ID

        //        var id = data.Firm_Name.FirstOrDefault();
        //        data.Id_No = Get_Id_No(id); //get new Id_No

        //        db2.Members_Data.Add(data);
        //        db2.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    return View(data);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShabmmaViewModel data)
        {
            if (ModelState.IsValid)
            {
                data.Members_Data.Registered_By = "Admin";
                data.Members_Data.Membership_Id = Get_Membership_Id(); //get new Membership_ID

                var id = data.Members_Data.Firm_Name.FirstOrDefault();
                data.Members_Data.Id_No = Get_Id_No(id); //get new Id_No

                data.Members_Dealing.Membership_Id = data.Members_Data.Membership_Id; //assign membership id to members_dealing table

                db2.Members_Data.Add(data.Members_Data);
                db2.Members_Dealing.Add(data.Members_Dealing);

                login new_user = new login();
                new_user.Username = data.Members_Data.Membership_Id;
                new_user.Password = Get_Temp_Password();
                new_user.ConfirmPassword = new_user.Password;
                new_user.Role = "v";

                db2.logins.Add(new_user);

                db2.SaveChanges();



                //using (MailMessage mail = new MailMessage())
                //{
                //    mail.From = new MailAddress("pateltrushil05@gmail.com");
                //    mail.To.Add(data.Members_Data.Email.ToString());
                //    mail.Subject = "Membership Information";
                //    mail.Body = "<h1> Welcome to SHABMMA!</h1><h2> Here are your login credentials:</h2><ul> <li> Username :" + new_user.Username+ "</li><li> Password: " + new_user.Password + "</li></ul><p><strong> Note:</strong> When you will login for the first time you will be asked to reset your password <p> &nbsp;</p><p> SHABMMA </p><p> &nbsp;</ p >";
                //    mail.IsBodyHtml = true;
                    

                //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                //    {
                //        smtp.Credentials = new NetworkCredential("pateltrushil05@gmail.com", "pateltrushil@401");
                //        smtp.EnableSsl = true;
                //        smtp.Send(mail);
                //    }
                //}
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("info@shabmma.in");
                    mail.To.Add(data.Members_Data.Email.ToString());
                    mail.Subject = "Membership Information";
                    mail.Body = "<h1> Welcome to SHABMMA!</h1><h2> Here are your login credentials:</h2><ul> <li> Username :" + new_user.Username + "</li><li> Password: " + new_user.Password + "</li></ul><p><strong> Note:</strong> When you will login for the first time you will be asked to reset your password <p> &nbsp;</p>To Login to your account click " + "<a href=\"https://www.shabmma.in/Account/Login\">here</a>" +"<p> SHABMMA </p><p> &nbsp;</ p >";
                    mail.IsBodyHtml = true;


                    using (SmtpClient smtp = new SmtpClient("smtpout.secureserver.net", 587))
                    {
                        smtp.Credentials = new NetworkCredential("info@shabmma.in", "Pateltrushil@401");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                return RedirectToAction("Index");
            }

            return View(data);
        }


        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        private String Get_Temp_Password()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);

            return "T" + finalString;
        }
        private String Get_Membership_Id()
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new string(stringChars);
            finalString = "SH-" + finalString;
            //Members_Data d = db2.Members_Data.Find(finalString);
            var count1 = db2.Members_Data.Where(x => x.Membership_Id == finalString).Count();
            var count2 = db2.Members_Dealing.Where(x => x.Membership_Id == finalString).Count();
            var count3 = db2.logins.Where(x => x.Username == finalString).Count();
            if (count1 == 0 && count2 == 0 && count3 == 0)
            {
                return finalString;
            }
            else
            {
                return Get_Membership_Id();
            }
        }

        private String Get_Id_No(char s)
        {
            if (Char.IsLower(s))
            {
                s = Char.ToUpper(s);
            }

            for (int i = 1000; ; i++)
            {
                var finalString = s + i.ToString();
                var count = db2.Members_Data.Where(x => x.Id_No == finalString).Count();
                if (count == 0)
                {
                    return finalString;
                }
            }

        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members_Data datum = db2.Members_Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Members_Data datum)
        {
            if (ModelState.IsValid)
            {
                db2.Entry(datum).State = EntityState.Modified;
                db2.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datum);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members_Data datum = db2.Members_Data.Find(id);
            if (datum == null)
            {
                return HttpNotFound();
            }
            return View(datum);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Members_Data datum = db2.Members_Data.Find(id);
            db2.Members_Data.Remove(datum);
            db2.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db2.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
