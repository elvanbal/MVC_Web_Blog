using MVC_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private MVC_BlogEntities db = new MVC_BlogEntities();

        // GET: Admin
        public ActionResult UsersList()
        {
            var entities = new MVC_Web.Models.MVC_BlogEntities();

            return View(entities.Users.ToList());

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult CreateUser()
        {
            return View();
        }


        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateUser(Models.User user)
        {
            try
            {
                user.LastLoginDate = DateTime.Now;

                db.Users.Add(user);
                db.SaveChanges();


                return RedirectToAction("UsersList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult EditUser(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVC_Web.Models.User usr = db.Users.Find(id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            return View(usr);

        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditUser(int id, Models.User collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(collection).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UsersList");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult DeleteUser(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.User usr = db.Users.Find(id);
            if (usr == null)
            {
                return HttpNotFound();
            }
            return View(usr);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteUser(int id, FormCollection collection)
        {
            try
            {
                try
                {
                    Models.User art = db.Users.Find(id);
                    db.Users.Remove(art);
                    db.SaveChanges();
                    return RedirectToAction("UsersList");
                }
                catch
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
