using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//Controller for Authentication

namespace ProjectManagement.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string userid,string password)
        {
          //  ViewBag.data = userid + password;
            if (ModelState.IsValid)
            {
                using (ProjectContext pc = new ProjectContext())
                {
                    var std = pc.Students.FirstOrDefault(s => s.Id == userid && s.password == password);
                    if (std == null)
                    {
                        ViewBag.msg = "Please Enter Valid Data ";
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(userid, false);
                        Session["userid"] = userid.ToString();

                        if (!string.IsNullOrEmpty(Request.Form["ReturnUrl"]))
                        {
                            return Redirect(Request.Form["ReturnUrl"]);
                        }
                        else
                        {
                            if (User.IsInRole("Faculty"))
                            {
                                return Redirect("~/Faculty/Index");
                            }
                            else if(User.IsInRole("Student"))
                            {
                                return Redirect("~/Student/Index");
                            }
                        }
                    }
                }
            }
                return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Student s,string Role)
        {
            ViewBag.role = "data Added";
            using (ProjectContext pc=new ProjectContext()) {
                UserRole ur = new UserRole();
                ur.role = Role;
                ur.std = s;
                pc.Roles.Add(ur);
                pc.SaveChanges();

            }
                return Redirect("~/Auth/Login");
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["userid"] = null;
            return Redirect("~/Auth/Login");
        }
    }
}