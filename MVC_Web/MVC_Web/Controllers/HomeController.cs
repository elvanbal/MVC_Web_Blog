using MVC_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Web.Controllers
{
    public class HomeController : Controller
    {

        public string _username;
        public string _password;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewController.LoginViewModel user, string url)
        {
            if (ModelState.IsValid)
            {
                using (MVC_BlogEntities  db = new MVC_BlogEntities())
                {
                    var obj = db.Users.Where(a => a.NickName.Equals(user.UserName ) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        Session["Name"] = obj.NickName.ToString();
                        FormsAuthentication.SetAuthCookie(obj.NickName , false);
                      
                        return RedirectToAction("UserDashBoard");
                    }
                } 
                 
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("ArticleList", "Article");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("ArticleList", "Article");
        }

    }
}