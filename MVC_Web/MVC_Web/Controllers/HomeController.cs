using MVC_Web.Models;
using Newtonsoft.Json;
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
                using (MVC_BlogEntities db = new MVC_BlogEntities())
                {
                    var obj = db.Users.Where(a => a.NickName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        var UserID = obj.UserId;

                        var query1 = from ur in db.UserRoles      //rolleri getiren sorgu
                                     join r in db.Roles on ur.RoleId equals r.RoleId into gj
                                     from subpet in gj
                                     where ur.UserId == UserID
                                     select new { RoleName = subpet.RoleName };



                        var userRoles = query1.Select(x => x.RoleName).ToArray();   //kullanıcının rol listesi

                        var usr = new CustomPrincipalSerializeModel();
                        usr.UserId = UserID;
                        usr.UserName = obj.UserName;
                        usr.Name = obj.NickName;
                        usr.Email = obj.Email;
                        usr.roles = userRoles;       //Kullanıcı tanımlaması

                        string userData = JsonConvert.SerializeObject(usr);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            usr.UserId ,usr.Email,DateTime.Now,DateTime.Now.AddMinutes(15),false,userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);


                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.UserName.ToString();
                        //Session["Name"] = obj.NickName.ToString();
                        //FormsAuthentication.SetAuthCookie(obj.NickName ,true );



                        return RedirectToAction("UserDashBoard");
                    }
                }

            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Request.IsAuthenticated == true )
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